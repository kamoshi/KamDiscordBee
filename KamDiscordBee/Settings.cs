using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;

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




        // Methods
        public void Save()
        {

        }

        // Saving / Loading
        public void Save(string path)
        {

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
    }
}
