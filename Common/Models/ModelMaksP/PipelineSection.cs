﻿using System;
using System.Collections.Generic;

namespace Common.Models
{
    public class PipelineSection : BaseModel
    {
        public string NumberOfSection { get; set; }
        public int Length { get; set; }
        public DateTime LastRepair { get; set; }

        public Guid SteelPipeId { get; set; }
        public SteelPipe SteelPipe { get; set; }

        public Guid ThermalNetworkId { get; set; }
        public ThermalNetwork ThermalNetwork { get; set; }

        public List<ThermalNode> Nodes { get; set; }

        public PipelineSection()
        {
            Nodes = new List<ThermalNode>();
        }
    }
}
