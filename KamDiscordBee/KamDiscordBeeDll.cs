using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DiscordRPC;

namespace MusicBeePlugin
{
    public partial class Plugin
    {
        private MusicBeeApiInterface mbApiInterface;
        private PluginInfo about = new PluginInfo();
        private static DiscordRpcClient client = new DiscordRpcClient("771555853513129984");

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
                    if (!client.IsInitialized) client.Initialize();
                    break;
                case NotificationType.PlayStateChanged:
                    string album = mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Album);
                    string artist = mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Artist);
                    string albumArtist = mbApiInterface.NowPlaying_GetFileTag(MetaDataType.AlbumArtist);
                    string songTitle = mbApiInterface.NowPlaying_GetFileTag(MetaDataType.TrackTitle);
                    string code = mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Custom1);
                    
                    // perform startup initialisation
                    switch (mbApiInterface.Player_GetPlayState())
                    {
                        case PlayState.Playing:
                        case PlayState.Paused:
                        case PlayState.Stopped:
                            updatePresenceState("ardw0003", "Top line", "Bottom line", "Description");
                            break;
                    }
                    break;
            }
        }

        // Provided data should be preformatted with the correct value.
        private void updatePresenceState(string albumCover, string topLine, string bottomLine, string description)
        {
            albumCover = albumCover != "" ? albumCover : "jammin"; // in case it's empty
            client.SetPresence(new RichPresence()
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
    }
}