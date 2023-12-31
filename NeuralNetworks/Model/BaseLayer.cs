﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Model
{
    public abstract class BaseLayer
    {
        public string Name { get; set; }
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }

        protected BaseLayer(string name, bool isFirst = false, bool isLast = false)
        {
            Name = name;
            IsFirst = isFirst;
            IsLast = isLast;
        }

        public abstract List<double> CalculateOutput(List<double> input);
        public abstract LayerOptions.LayerType GetLayerType();
    }
}
