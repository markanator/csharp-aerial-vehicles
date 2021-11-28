using OOPFlyingVehicleCore.Interfaces;
using OOPFlyingVehicleCore.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class Engine : IEngine
    {
        public bool IsStarted { get; set; }

        public Engine()
        {
            this.IsStarted = false;
        }

        public string About()
        {
            string engineString = this.ToString() + " is not started.";
            if (this.IsStarted)
            {
                engineString = engineString.Replace("not ", "");
            }
            return engineString;
        }

        public void Start()
        {
            this.IsStarted = true;
        }

        public void Stop()
        {
            this.IsStarted = false;
        }
    }
}
