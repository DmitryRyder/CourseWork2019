using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class TestData : BaseModel
    {
        public string Name { get; set; }
        public double SurfaceArea { get; set; }
        public string Mass { get; set; }
        public int Temperature { get; set; }
        public int Radius { get; set; }
    }
}
