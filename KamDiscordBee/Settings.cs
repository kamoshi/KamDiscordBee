using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace MusicBeePlugin
{
    [DataContract]
    class Settings
    {
        // App Id
        [DataMember] private string _applicationId;
        public string ApplicationId
        {
            get => _applicationId ?? "792839742709432411";
            set => _applicationId = value;
        }

        // IMAGE STUFF
        [DataMember] private string _imageDetail;
        public string ImageDetail
        {
            get => _imageDetail ?? "[Album] by [AlbumArtist]";
            set => _imageDetail = value;
        }

        [DataMember] private bool _imageUseAssetKey = false;
        public bool ImageUseAssetKey
        {
            get => _imageUseAssetKey;
            set => _imageUseAssetKey = value;
        }

        [DataMember] private string _imageAssetKey;
        public string ImageAssetKey
        {
            get => _imageAssetKey ?? "[Custom1]";
            set => _imageAssetKey = value;
        }

        // INFO STUFF
        [DataMember] private string _topLine;
        public string TopLine
        {
            get => _topLine ?? "[Album]";
            set => _topLine = value;
        }

        [DataMember] private string _bottomLine;
        public string BottomLine
        {
            get => _bottomLine ?? "[TrackTitle] by [Artist]";
            set => _bottomLine = value;
        }

        [DataMember] private bool _showTime = true;
        public bool ShowTime
        {
            get => _showTime;
            set => _showTime = value;
        }

        [DataMember] private bool _showRemainingTime = false;
        public bool ShowRemainingTime
        {
            get => _showRemainingTime;
            set => _showRemainingTime = value;
        }

        [DataMember] private bool _showTrackNumber = true;
        public bool ShowTrackNumber
        {
            get => _showTrackNumber;
            set => _showTrackNumber = value;
        }

        // Saving / Loading
        public void Save(string path)
        {
            {
                string dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            }
            using (var xmlWriter = XmlWriter.Create(path))
            {
                var serializer = new DataContractSerializer(typeof(Settings));
                serializer.WriteObject(xmlWriter, this);
                xmlWriter.Flush();
            }
        }

        public static Settings Load(string path)
        {
            if (File.Exists(path))
            {
                using (var file = File.OpenRead(path))
                {
                    var serializer = new DataContractSerializer(typeof(Settings));
                    return serializer.ReadObject(file) as Settings;
                }
            }
            else return new Settings();
        }

        internal static void Clear(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }
    }
}
