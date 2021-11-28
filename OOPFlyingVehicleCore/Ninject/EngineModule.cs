using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using OOPFlyingVehicle;
using OOPFlyingVehicleCore.EngineClasses;
using OOPFlyingVehicleCore.Interfaces;

namespace OOPFlyingVehicleCore.Ninject
{
    public class EngineModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>();
            // if they ask for xx, they get zz
            this.Bind<IEngine>().To<JetEngine>().WhenInjectedExactlyInto<Airplane>();
            this.Bind<IEngine>().To<ReciprocatingEngine>().WhenInjectedInto<Helicopter>();
            this.Bind<IEngine>().To<RubberBandEngine>().WhenInjectedExactlyInto<ToyPlane>();
            this.Bind<IEngine>().To<UAVEngine>().WhenInjectedInto<Drone>();
        }
    }
}
