using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class ToyPlane : Airplane
    {
        bool isWoundUP { get; }

        public ToyPlane()
        {
            this.MaxAltitude = 50;
            this.Engine = new RubberBandEngine();
        }

        public override void StartEngine()
        {
            if (this.isWoundUP)
            {
                base.StartEngine();
            }
        }
        public override void StopEngine()
        {
            if (base.CurrentAltitude == 0)
            {
                base.StopEngine();
            }
        }

        public override string TakeOff()
        {
            if (base.Engine.IsStarted)
            {
                base.IsFlying = true;
                return $"{this.ToString()} is flying";
            }

            return "";
        }

        public void WindUp()
        {
            while (((RubberBandEngine)Engine).IsFullyWound == false)
            {
                this.Wind();
            }
        }

        public void Wind()
        {
            ((RubberBandEngine)Engine).Wind();
        }

        public void UnWind()
        {
            this.UnWindCompletely();
        }

        public void UnWindCompletely()
        {
            if (this.CurrentAltitude == 0)
            {
                ((RubberBandEngine)Engine).NumWinds = 0;
            }
        }

        protected string getWindUpString()
        {
            string woundUp = "It's not wound up.";
            if(isWoundUP) woundUp = woundUp.Replace("not ", "");
            return woundUp;
        }

        public override string About()
        {
            return base.About() + "\n" + this.getWindUpString();
        }
    }
}
