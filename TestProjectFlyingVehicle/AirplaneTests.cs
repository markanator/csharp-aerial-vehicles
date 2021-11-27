using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPFlyingVehicle;

namespace UnitTestFlyingVehicle
{
    [TestClass]
    public class AirplaneTests
    {
        private Airplane airplane;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public Airplane Airplane
        {
            get
            {
                return airplane;
            }
            set
            {
                airplane = value;
            }
        }

        public AirplaneTests()
        {
            Airplane = new Airplane();
        }

        [TestMethod]
        public void AirplaneAbout()
        {
            //Arrange 
            Airplane ap = this.Airplane;
            //Act

            //Assert
            Assert.AreEqual(ap.About(), $"This {ap.ToString()} has a max altitude of 41000 ft. \nIt's current altitude is 0 ft. \n{ap.Engine.ToString()} is not started.");
        }

        [TestMethod]
        public void AireplaneTakeOff()
        {
            //Arrange 
            Airplane ap = this.Airplane;
            
            //act
            string firstTakeoff = ap.TakeOff();
            bool engineBeforeStart = ap.Engine.IsStarted;
            ap.StartEngine();
            string secondTakeOff = ap.TakeOff();

            //Assert
            Assert.AreEqual(firstTakeoff, ap.ToString() + " can't fly it's engine is not started.");
            Assert.AreEqual(secondTakeOff, ap.ToString() + " is flying");
            Assert.AreEqual(engineBeforeStart, false);
            Assert.AreEqual(ap.Engine.IsStarted, true);
        }

        [TestMethod]
        public void AireplaneFlyUp()
        {
            //Arrange 
            Airplane ap = this.Airplane;

            //act
            ap.StartEngine();
            string firstTakeoff = ap.TakeOff();
            int defaultHeight = ap.CurrentAltitude;
            ap.FlyUp();
            int firstAlt = ap.CurrentAltitude;
            ap.FlyUp(40000);
            int secondAlt = ap.CurrentAltitude;
            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(firstAlt, 1000);
            Assert.AreEqual(secondAlt, 41000);

        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(100)]
        [DataRow(1000)]
        public void AireplaneFlyUpHowMuch(int HowMuch)
        {
            //Arrange 
            Airplane ap = this.Airplane;
            int startingAlt, endingAlt;
            startingAlt = ap.CurrentAltitude;
            //act
            ap.StartEngine();
            string firstTakeoff = ap.TakeOff();
            ap.FlyUp(HowMuch);
            endingAlt = ap.CurrentAltitude;

            //Assert
            Assert.AreEqual(startingAlt + HowMuch, endingAlt);

        }

        /// <summary>
        ///     An example of a test that is expected to throw an exception.
        /// </summary>
        /// <exception cref="System.Exception">oops</exception>
        [TestMethod]
        [DataRow(-100)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AireplaneFlyUpHowMuchExeption(int HowMuch)
        {
            Airplane.FlyUp(HowMuch);
        }

        
        
        [TestMethod]
        [DataRow(-100)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AireplaneFlyDownHowMuchExeption(int HowMuch)
        {
            Airplane.FlyDown(HowMuch);
        }

        [TestMethod]
        public void AireplaneFlyDownHowMuchExeptionMessage()
        {
            //Arrange
            string exceptionMessage = "Can't FlyDown a negative amount";
            //Act
            var ex = Assert.ThrowsException<InvalidOperationException>(() => Airplane.FlyDown(-1));
            //Assert

            Assert.AreEqual(exceptionMessage, ex.Message);
            Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
        }


        [TestMethod]
        public void AireplaneFlyDown()
        {
            //Arrange 
            Airplane ap = this.Airplane;

            //act
            ap.StartEngine();
            string firstTakeoff = ap.TakeOff();
            int defaultHeight = ap.CurrentAltitude;
            ap.FlyDown();
            //test is flying again
            int FlyDown = ap.CurrentAltitude;
            ap.TakeOff();
            ap.FlyDown(1);
            //test is flying again
            ap.TakeOff();
            int FlyDownOneAlreadyZero = ap.CurrentAltitude;
            ap.FlyUp(2);
            ap.FlyDown(1);
            int FlyDownOneAtTwo = ap.CurrentAltitude;

            //Assert
            Assert.AreEqual(defaultHeight, 0);
            Assert.AreEqual(FlyDown, 0);
            //Assert.AreEqual(FlyDownOneAlreadyZero, 0);
            Assert.AreEqual(FlyDownOneAtTwo, 1);


        }
    }
}
