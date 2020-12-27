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

        // Discord RPC
        private DiscordRpcClient discordRpcClient;
        private Dictionary<string, Func<string>> metaDataDelegates;
        private RichPresence presence;

        // Settings
        private string settingsPath;
        private Settings settings;

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
            about.ReceiveNotifications = ReceiveNotificationFlags.PlayerEvents;
            about.ConfigurationPanelHeight = 0;
            
            // Discord RPC
            discordRpcClient = new DiscordRpcClient("771555853513129984");
            presence = new RichPresence() {
                Assets = new Assets() {
                    LargeImageKey = "default",
                    LargeImageText = $"MusicBee {mbApiInterface.MusicBeeVersion}",
                    SmallImageKey = "stopped"
                }
            };
            discordRpcClient.Initialize();
            metaDataDelegates = GetMetaDataDelegates();

            // Settings
            settingsPath = mbApiInterface.Setting_GetPersistentStoragePath() + about.Name + "\\settings.xml";
            settings = Settings.Load(settingsPath);

            return about;
        }

        public bool Configure(IntPtr panelHandle)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.Show();
            return true;
        }
       
        // called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        public void SaveSettings()
        {
            settings.Save(settingsPath);
        }

        // MusicBee is closing the plugin (plugin is being disabled by user or MusicBee is shutting down)
        public void Close(PluginCloseReason reason)
        {
            discordRpcClient.ClearPresence();
            discordRpcClient.Dispose();
        }

        // uninstall this plugin - clean up any persisted files
        public void Uninstall()
        {
            Settings.Clear(settingsPath);
        }

        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            switch (type)
            {
                case NotificationType.PluginStartup:
                case NotificationType.PlayStateChanged:
                case NotificationType.TrackChanged:
                    switch (mbApiInterface.Player_GetPlayState())
                    {
                        case PlayState.Playing:
                            UpdatePresencePlayState("playing", true, false);
                            break;
                        case PlayState.Paused:
                            UpdatePresencePlayState("paused", false, false);
                            break;
                        case PlayState.Stopped:
                            UpdatePresencePlayState("stopped", false, false);
                            break;
                    }
                    string imageTag = ReplaceTags("[Custom1]");
                    string imageDescription = ReplaceTags("[Custom1]");
                    string topLine = ReplaceTags(settings.TopLine);
                    string bottomLine = ReplaceTags(settings.BottomLine);
                    UpdatePresenceInfoState(imageTag, topLine, bottomLine, imageDescription);
                    break;
            }
        }

        // Updates rich presence information
        // provided data should be preformatted with the metadata values
        private void UpdatePresenceInfoState(string albumCover, string topLine, string bottomLine, string description)
        {
            albumCover = albumCover != "" ? albumCover : "default"; // in case it's empty
            presence.Details = topLine;
            presence.State = bottomLine;
            presence.Assets.LargeImageKey = albumCover.ToLowerInvariant();
            presence.Assets.LargeImageText = description;
            discordRpcClient.SetPresence(presence);
        }

        // Updates player state and time in rich presence
        private void UpdatePresencePlayState(string smallImageKey, bool displayTime, bool showRemaining)
        {
            presence.Assets.SmallImageKey = smallImageKey;
            presence.Assets.SmallImageText = smallImageKey;
            if (displayTime)
            {
                presence.Timestamps = new Timestamps();
                int playerPositionMillis = mbApiInterface.Player_GetPosition();
                if (showRemaining)
                {
                    int songLengthMillis = mbApiInterface.NowPlaying_GetDuration();
                    presence.Timestamps.Start = DateTime.UtcNow.AddMilliseconds(-playerPositionMillis);
                    presence.Timestamps.End = DateTime.UtcNow.AddMilliseconds(songLengthMillis - playerPositionMillis);
                }
                else
                {
                    presence.Timestamps.Start = DateTime.UtcNow.AddMilliseconds(-playerPositionMillis);
                    presence.Timestamps.End = null;
                }
            }
            else presence.Timestamps = null;
        }

        // Replaces tags in string with metadata
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
                        else stringBuffer.Append($"[{tagString}]");
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

        // Provides easy access to MusicBee metadata by enum name
        private Dictionary<string, Func<string>> GetMetaDataDelegates()
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