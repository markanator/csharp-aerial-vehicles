using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPFlyingVehicle;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class ToyPlaneTests
    {

        ToyPlane tp;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Executes once for the test class. (Optional)
        }

        public ToyPlaneTests()
        {
            tp = new ToyPlane(new RubberBandEngine());
        }

        /// <summary>
        /// runs before each test (Optional)
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            //If I want the toyplane in a known state
            tp.StopEngine();
            tp.UnWindCompletely();
        }

        /// <summary>
        /// runs after each test
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
            //nothing really to do with toyplane
        }

        [TestMethod]
        [TestCategory("ToyEngine")]
        public void ToyplaneHasAToyEngine()
        {
            //Arrange
            //tp.StopEngine();
            //tp.UnWind();
            //act
            
            //asset
            Assert.IsInstanceOfType(tp.Engine, typeof(RubberBandEngine));
        }

        [TestMethod]
        [TestCategory("ToyEngine")]
        public void ToyPlaneNotWoundEngineIsStarted()
        {
            //Arrange
            tp.StopEngine();
            tp.UnWind();
            //Act
            bool EngineBeforeStart, EngineAfterStart;
            EngineBeforeStart = tp.Engine.IsStarted;
            tp.StartEngine();
            EngineAfterStart = tp.Engine.IsStarted;
            //Assert
            Assert.IsFalse(EngineBeforeStart);
            Assert.IsFalse(EngineAfterStart);
        }

        [TestMethod]
        [TestCategory("ToyEngine")]
        [Ignore]
        public void ToyPlanEngineWoundIsStarted()
        {
            //Arrange
            tp.StopEngine();
            tp.WindUp();
            //Act
            bool EngineBeforeStart, EngineAfterStart;
            EngineBeforeStart = tp.Engine.IsStarted;
            tp.StartEngine();
            EngineAfterStart = tp.Engine.IsStarted;
            //Assert
            Assert.IsFalse(EngineBeforeStart);
            Assert.IsTrue(EngineAfterStart);
        }

        [TestMethod]
        [TestCategory("Winding")]
        public void ToyPlaneWind()
        {
            //Arrange
            int windsbefore, windsafter;
            RubberBandEngine engine = tp.Engine as RubberBandEngine;
            //Act
            
            windsbefore = engine.NumWinds;
            windsafter = windsbefore + 1;
            tp.Wind();

            //Assert
            Assert.AreEqual(engine.NumWinds, windsafter);
        }

        [TestMethod]
        [TestCategory("Winding")]
        public void ToyPlaneUnWind()
        {
            //Arrange
            int windsbefore, windsafter;
            RubberBandEngine engine = tp.Engine as RubberBandEngine;
            engine.NumWinds = 1;
            //Act

            windsbefore = engine.NumWinds;
            windsafter = windsbefore -1;
            tp.UnWind();

            //Assert
            Assert.AreEqual(engine.NumWinds, windsafter);
        }

        [TestMethod]
        [TestCategory("Winding")]
        public void ToyPlaneWindUp()
        {
            //Arrange
            int windsbefore, windsafter;
            int EngineDefaultMaxWinds;
            RubberBandEngine engine = tp.Engine as RubberBandEngine;
            //Act
            EngineDefaultMaxWinds = 20;
            windsbefore = engine.NumWinds;
            windsafter = EngineDefaultMaxWinds;
            tp.WindUp();

            //Assert
            Assert.AreEqual(engine.NumWinds, windsafter);
        }

        [TestMethod]
        [TestCategory("Winding")]
        public void ToyPlaneUnWindCompletely()
        {
            //Arrange
            RubberBandEngine engine = tp.Engine as RubberBandEngine;
            //Act
            tp.UnWind();
            //Assert
            Assert.AreEqual(0, engine.NumWinds);
        }
    }
}
