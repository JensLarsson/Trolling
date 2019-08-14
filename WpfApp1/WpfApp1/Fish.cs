using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Fish
    {
        public string displayString
        {
            get { return $"{weight.ToString()}g {fishType.Name}"; }
        }
        public float weight { get; set; }
        public FishType fishType { get; set; }
    }

    public class FishType
    {
        public string Name { get; set; }
    }
}
