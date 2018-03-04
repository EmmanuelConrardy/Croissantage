using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Croissantage.Tests
{
    [TestClass]
    public class EmployeTests
    {
        [TestMethod]
        public void Employe_Should_Not_Be_Croissanted_When_He_Is_In_Is_Place_Origin()
        {
            var placeOrigin = Place.OpenSpace;
            var employe = new Employe("EmployeName",placeOrigin);

            var result = employe.CanBeCroissanted();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Employe_Should_Be_Croissanted_When_He_Move_To_An_Other_Place()
        {
            var placeOrigin = Place.OpenSpace;
            var otherPlace = Place.Printer;
            var employe = new Employe("EmployeName", placeOrigin);

            employe.MoveTo(otherPlace);
            var result = employe.CanBeCroissanted();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Employe_Should_Not_Be_Croissanted_When_He_AlreadyHasBeenCroissanted()
        {
            var placeOrigin = Place.OpenSpace;
            var otherPlace = Place.Printer;
            var employe = new Employe("EmployeName", placeOrigin);

            employe.hasBeenAlreadyCroissanted = true;
            employe.MoveTo(otherPlace);
            var result = employe.CanBeCroissanted();

            Assert.IsFalse(result);
        }
    }
}
