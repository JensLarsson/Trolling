using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WpfApp1
{
    class XML_Mediator
    {
        string folder;
        public XML_Mediator(string s)
        {
            
            folder = Directory.GetCurrentDirectory() + "/Teams/" + s + "/";
        }

        public List<Team> loadTeams()
        {
            List<Team> teams = new List<Team>();
            string folderPath = folder;

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                Team team = new Team();
                string s = file.Remove(0, folderPath.Count() + 1);
                team.Name = s.Substring(0, s.Length - 4);
                XmlSerializer serializer = new XmlSerializer(typeof(Team));
                TextReader reader = new StreamReader(file);
                object obj = serializer.Deserialize(reader);
                team = (Team)obj;
                reader.Close();
                teams.Add(team);
            }
            return teams;
        }

        public void SaveTeam(Team team, bool newTeam = false)
        {
            if (newTeam)
            {
                team.day1 = new List<Fish>();
                team.day2 = new List<Fish>();
                team.day3 = new List<Fish>();
            }
            string folderPath = folder + team.Name + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Team));
            using (TextWriter tw = new StreamWriter(folderPath))
            {
                serializer.Serialize(tw, team);
            }
        }

        public void SaveFishes(List<FishType> fishes)
        {
            string folderPath = Directory.GetCurrentDirectory() + "/fishes.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<FishType>));
            using (TextWriter tw = new StreamWriter(folderPath))
            {
                serializer.Serialize(tw, fishes);
            }
        }

        public List<FishType> loadFishTypes()
        {
            List<FishType> fishes = new List<FishType>();
            string filePath = Directory.GetCurrentDirectory() + "/fishes.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<FishType>));
            TextReader reader = new StreamReader(filePath);
            object obj = serializer.Deserialize(reader);
            fishes = (List<FishType>)obj;
            reader.Close();

            return fishes;
        }

        public void saveInfo(Info info)
        {
            string folderPath = folder + "info/info.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Info));
            using (TextWriter tw = new StreamWriter(folderPath))
            {
                serializer.Serialize(tw, info);
            }
        }

        public Info loadInfo()
        {
            Directory.CreateDirectory(folder + "/info");
            string folderPath = folder + "info/info.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(folderPath);
            XmlSerializer serializer = new XmlSerializer(typeof(Info));
            TextReader reader = new StreamReader(folderPath);
            object obj = serializer.Deserialize(reader);
            Info info = (Info)obj;
            reader.Close();
            return info;
        }

        public void DeleteTeam(Team team)
        {
            File.Delete(folder + team.Name + ".xml");
        }
    }
}