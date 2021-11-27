using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFlyingVehicle
{
    public class ToyEngine : Engine
    {
        public int NumWinds { get; set; }
        public int NumWindsFullyWound { get; set; }

        public bool IsFullyWound { 
            get { return NumWinds >= NumWindsFullyWound; } 
        }

        public ToyEngine()
        {
            this.NumWindsFullyWound = 20;
        }

        public override void Stop()
        {
            if (base.IsStarted)
            {
                base.Stop();
            }
        }
        public override void Start()
        {
            if (this.IsFullyWound)
            {
                base.Start();
            }
        }

        public override string About()
        {
            return base.About();
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
