using OOPFlyingVehicleCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class Airplane : AerialVehicle
    {
        public Airplane(IEngine eng) : base(eng)
        {
            this.MaxAltitude = 41000;
        }
    }
}
