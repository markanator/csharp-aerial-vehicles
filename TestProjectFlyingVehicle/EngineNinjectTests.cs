using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OOPFlyingVehicle;
using OOPFlyingVehicleCore.EngineClasses;
using OOPFlyingVehicleCore.Ninject;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class EngineNinjectTests
    {
        IKernel kernel;

        public EngineNinjectTests()
        {
            kernel = new StandardKernel(new EngineModule());
        }

        [TestMethod]
        public void AirplaneGetsAJetEngine()
        {
            // Arrange
            AerialVehicle plane = kernel.Get<Airplane>();
            // Assert
            Assert.IsInstanceOfType(plane.Engine, typeof(JetEngine));
        }
        [TestMethod]
        public void HelicopterGetsAReciprocatingEngine()
        {
            // Arrange
            AerialVehicle plane = kernel.Get<Helicopter>();
            // Assert
            Assert.IsInstanceOfType(plane.Engine, typeof(ReciprocatingEngine));
        }
        [TestMethod]
        public void ToyPlaneGetsRubberBandEngine()
        {
            // Arrange
            AerialVehicle plane = kernel.Get<ToyPlane>();
            // Assert
            Assert.IsInstanceOfType(plane.Engine, typeof(RubberBandEngine));
        }
        [TestMethod]
        public void DroneGetsUAVEngine()
        {
            // Arrange
            AerialVehicle plane = kernel.Get<Drone>();
            // Assert
            Assert.IsInstanceOfType(plane.Engine, typeof(UAVEngine));
        }
    }
}
