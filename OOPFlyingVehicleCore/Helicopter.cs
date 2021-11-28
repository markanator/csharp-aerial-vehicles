using OOPFlyingVehicleCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class Helicopter : AerialVehicle
    {
        public Helicopter(IEngine eng): base(eng)
        {
            this.MaxAltitude = 8000;
        }
    }
}
