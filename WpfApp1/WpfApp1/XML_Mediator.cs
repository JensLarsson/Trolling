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
            folder = Directory.GetCurrentDirectory() + "/Teams/" + s +"/";
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

        public void SaveTeam(Team team)
        {
            string folderPath = folder + team.Name + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Team));
            using (TextWriter tw = new StreamWriter(folderPath))
            {
                serializer.Serialize(tw, team);
            }
        }

        public void DeleteTeam(Team team)
        {
            File.Delete(folder + team.Name + ".xml");
        }
    }
}