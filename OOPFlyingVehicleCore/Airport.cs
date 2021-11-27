using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class Airport
    {

        public List<AerialVehicle> Vehicles { get; protected set; }
        public int MaxVehicles { get; protected set; }
        public string AirportCode { get; protected set; }

        private static int defaultMaxVehicles = 5;

        public Airport(string Code) : this(Code, defaultMaxVehicles)
        {
            ////Default to 5 vehicles
            this.Vehicles = new List<AerialVehicle>(defaultMaxVehicles);
            this.AirportCode = Code;
            this.MaxVehicles = defaultMaxVehicles;
        }

        public Airport(string Code, int MaxVehicles)
        {
            this.Vehicles = new List<AerialVehicle>(MaxVehicles);
            this.AirportCode = Code;
            this.MaxVehicles = MaxVehicles;
        }

        public string Land(AerialVehicle a)
        {
            //Don't allow more vehicle to lan than the max
            if (this.Vehicles.Count < this.MaxVehicles)
            {
                this.Vehicles.Add(a);
                //Set vehicle altitude to 0
                if (a.CurrentAltitude > 0)
                {
                    a.FlyDown(a.CurrentAltitude);
                }
                return string.Format("{0} lands at {1}", a, this.AirportCode);
            }
            return string.Format("{0} is full can't land here",this.AirportCode);
        }

        public string TakeOff(AerialVehicle a)
        {
            return a.TakeOff() + " from " + this.AirportCode;
        }

        public string AllTakeOff()
        {
            string allTakeOff = string.Empty;
            for (int i = 0; i < this.Vehicles.Count; i++)
            {
                allTakeOff += this.TakeOff(this.Vehicles[i]);
            }
            
            return allTakeOff;

        }

        public string Land(List<AerialVehicle> landing)
        {
            string stringLand = string.Empty;
            foreach(AerialVehicle av in landing)
            {
                stringLand += this.Land(av);   
            }

            return stringLand;
        }

    }
}
