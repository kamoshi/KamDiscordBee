using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DiscordRPC;
using System.Text;

namespace MusicBeePlugin
{
    public partial class Plugin
    {
        private MusicBeeApiInterface mbApiInterface;
        private PluginInfo about = new PluginInfo();

        // Additional fields
        private static DiscordRpcClient discordRpcClient;
        private static Dictionary<string, Func<string>> metaDataDelegates;

        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            mbApiInterface = new MusicBeeApiInterface();
            mbApiInterface.Initialise(apiInterfacePtr);
            about.PluginInfoVersion = PluginInfoVersion;
            about.Name = "KamDiscordBee";
            about.Description = "Plugin provides rich presence for MusicBee";
            about.Author = "kamoshi";
            about.TargetApplication = "MusicBee";   //  the name of a Plugin Storage device or panel header for a dockable panel
            about.Type = PluginType.General;
            about.VersionMajor = 1;  // your plugin version
            about.VersionMinor = 0;
            about.Revision = 0;
            about.MinInterfaceVersion = MinInterfaceVersion;
            about.MinApiRevision = MinApiRevision;
            about.ReceiveNotifications = (ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.TagEvents);
            about.ConfigurationPanelHeight = 0;   // height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function
            
            discordRpcClient = new DiscordRpcClient("771555853513129984");
            discordRpcClient.Initialize();
            metaDataDelegates = GetMetaDataDict();
            return about;
        }

        public bool Configure(IntPtr panelHandle)
        {
            // save any persistent settings in a sub-folder of this path
            string dataPath = mbApiInterface.Setting_GetPersistentStoragePath();
            // panelHandle will only be set if you set about.ConfigurationPanelHeight to a non-zero value
            // keep in mind the panel width is scaled according to the font the user has selected
            // if about.ConfigurationPanelHeight is set to 0, you can display your own popup window
            if (panelHandle != IntPtr.Zero)
            {
                Panel configPanel = (Panel)Panel.FromHandle(panelHandle);
                Label prompt = new Label();
                prompt.AutoSize = true;
                prompt.Location = new Point(0, 0);
                prompt.Text = "prompt:";
                TextBox textBox = new TextBox();
                textBox.Bounds = new Rectangle(60, 0, 100, textBox.Height);
                configPanel.Controls.AddRange(new Control[] { prompt, textBox });
            }
            return false;
        }
       
        // called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        // its up to you to figure out whether anything has changed and needs updating
        public void SaveSettings()
        {
            // save any persistent settings in a sub-folder of this path
            string dataPath = mbApiInterface.Setting_GetPersistentStoragePath();
        }

        // MusicBee is closing the plugin (plugin is being disabled by user or MusicBee is shutting down)
        public void Close(PluginCloseReason reason)
        {
        }

        // uninstall this plugin - clean up any persisted files
        public void Uninstall()
        {
        }

        // receive event notifications from MusicBee
        // you need to set about.ReceiveNotificationFlags = PlayerEvents to receive all notifications, and not just the startup event
        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            switch (type)
            {
                case NotificationType.PluginStartup:
                case NotificationType.PlayStateChanged:
                    // perform startup initialisation
                    switch (mbApiInterface.Player_GetPlayState())
                    {
                        case PlayState.Playing:
                        case PlayState.Paused:
                        case PlayState.Stopped:
                            UpdatePresenceState("ardw0003", ReplaceTags("[Album]"), ReplaceTags("[TrackTitle] by [Artist]"), "Description");
                            break;
                    }
                    break;
            }
        }

        // Provided data should be preformatted with the correct value.
        private void UpdatePresenceState(string albumCover, string topLine, string bottomLine, string description)
        {
            albumCover = albumCover != "" ? albumCover : "default_img"; // in case it's empty
            discordRpcClient.SetPresence(new RichPresence()
            {
                Details = topLine,
                State = bottomLine,
                Assets = new Assets()
                {
                    LargeImageKey = albumCover.ToLowerInvariant(),
                    LargeImageText = description,
                    SmallImageKey = "image_small"
                }
            });
        }

        private string ReplaceTags(string taggedString)
        {
            var stringBuffer = new StringBuilder();
            var tagBuffer = new StringBuilder();
            bool tag = false;
            for (int i = 0; i < taggedString.Length; i++)
            {
                if (tag)
                {
                    if (taggedString[i] == ']')
                    {
                        string tagString = tagBuffer.ToString();
                        if (metaDataDelegates.ContainsKey(tagString))
                        {
                            tagString = metaDataDelegates[tagString]();
                            stringBuffer.Append(tagString);
                        }
                        else stringBuffer.Append($"[{tagBuffer}]");
                        // cleanup
                        tagBuffer.Clear();
                        tag = false;
                    }
                    else tagBuffer.Append(taggedString[i]);
                }
                else
                {
                    if (taggedString[i] == '[') tag = true;
                    else stringBuffer.Append(taggedString[i]);
                }
            }
            if (tagBuffer.Length > 0) stringBuffer.Append(tagBuffer); // whatever is left in tagBuffer needs to go back
            return stringBuffer.ToString();
        }

        private Dictionary<string, Func<string>> GetMetaDataDict()
        {
            var dictionary = new Dictionary<string, Func<string>>();
            foreach (MetaDataType enumVal in Enum.GetValues(typeof(MetaDataType)))
            {
                string enumName = Enum.GetName(typeof(MetaDataType), enumVal);
                dictionary[enumName] = () => mbApiInterface.NowPlaying_GetFileTag(enumVal);
            }
            return dictionary;
        }
        
    }
}