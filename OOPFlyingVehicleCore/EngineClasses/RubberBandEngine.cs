using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFlyingVehicle
{
    public class RubberBandEngine : Engine
    {
        public int NumWinds { get; set; }
        public int NumWindsFullyWound { get; set; }

        public bool IsFullyWound { 
            get { return NumWinds >= NumWindsFullyWound; } 
        }

        public RubberBandEngine()
        {
            this.NumWindsFullyWound = 20;
        }

        public new void Stop()
        {
            if (base.IsStarted)
            {
                base.Stop();
            }
        }
        public new void Start()
        {
            if (this.IsFullyWound)
            {
                base.Start();
            }
        }

        internal void Wind()
        {
            this.NumWinds += 1;
        }

        internal void UnWind()
        {
            this.NumWinds -= 1;
        }
    }
}
