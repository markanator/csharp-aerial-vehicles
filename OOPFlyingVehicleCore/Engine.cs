using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class Engine
    {
        public bool IsStarted;

        public Engine()
        {
            this.IsStarted = false;
        }

        public virtual void Start()
        {
            this.IsStarted = true;
        }

        public virtual void Stop()
        {
            this.IsStarted = false;
        }

        public virtual string About()
        {
            string engineString = this.ToString() + " is not started.";
            if (this.IsStarted)
            {
                engineString = engineString.Replace("not ", "");
            }
            return engineString;
        }
    }
}
