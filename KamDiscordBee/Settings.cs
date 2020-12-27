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
