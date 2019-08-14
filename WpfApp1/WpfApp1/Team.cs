using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Team
    {
        public string Name { get; set; }
        public string marker;
        public List<Member> _members = new List<Member>();
        public float totalScore
        {
            get
            {
                return Day1 + Day2 + Day3;
            }
        }
        public List<Fish> day1 = new List<Fish>();
        public float Day1
        {
            get
            {
                float f = 0;
                float points = 0;
                for (int i = 0; i < day1.Count; i++)
                {
                    points += 20;
                    f += day1[i].weight;
                }
                points += f * 0.01f;
                return points;
            }
        }
        public List<Fish> day2 = new List<Fish>();
        public float Day2
        {
            get
            {
                float f = 0;
                float points = 0;
                for (int i = 0; i < day2.Count; i++)
                {
                    points += 20;
                    f += day2[i].weight;
                }
                points += f * 0.01f;
                return points;
            }
        }
        public List<Fish> day3 = new List<Fish>();
        public float Day3
        {
            get
            {
                float f = 0;
                float points = 0;
                for (int i = 0; i < day3.Count; i++)
                {
                    points += 20;
                    f += day3[i].weight;
                }
                points += f * 0.01f;
                return points;
            }
        }
    }
}
