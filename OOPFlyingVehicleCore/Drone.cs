using OOPFlyingVehicleCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class Drone : AerialVehicle
    {
        
        public Drone(IEngine _e): base(_e)
        {
            this.MaxAltitude = 500;
        }       
    }
}
