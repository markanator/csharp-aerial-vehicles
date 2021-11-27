using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPFlyingVehicle;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class AerialVehicleTests
    {

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException), "Cannot create an abstract class.")] //Since it's abstact it doesn't have constructor it will throw a MissingMethodException 
        
        public void AerialVehicleAstract_Throws()
        {
            var ae = Activator.CreateInstance<AerialVehicle>(); //Will throw
        }

        [TestMethod]
        public void AerialVehicleEngineTests()
        {
            //Arrange
            Airplane ap = new Airplane();
            //Act 
            bool defaultEngine = ap.Engine.IsStarted;  //default should be off
            ap.StartEngine();
            bool startedEngine = ap.Engine.IsStarted;
            ap.StopEngine();
            bool stoppedEngine = ap.Engine.IsStarted;

            //Assert
            Assert.AreEqual(defaultEngine, false); // default is stopped
            Assert.AreEqual(startedEngine, true); // after start is called engine should be stated
            Assert.AreEqual(stoppedEngine, false); // after stop is called engine should be stopped
        }
    }
}
