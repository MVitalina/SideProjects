using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfIndustryHelper
{
    public class Result
    {
        public bool IsRaw { get; set; } = false;
        public string ProductName { get; set; } = "";
        public string Building { get; set; } = "";
        public string Efficiency { get; set; } = "";         

        private int _buildingCount;
        public int BuildingCountToAdd
        { 
            get => _buildingCount;
            set { _buildingCount += value; }
        }
    }
}
