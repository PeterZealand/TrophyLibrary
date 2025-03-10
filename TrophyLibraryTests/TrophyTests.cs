using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLibrary.TrophyLibrary;
using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TrophyLibrary.TrophyLibrary.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void IdPropertyTest()
        {
            var trophy = new Trophy();
            trophy.Id = 1;
            Assert.AreEqual(1, trophy.Id);
        }

        [TestMethod()]
        public void CompetitionPropertyTest()
        {
            var trophy = new Trophy();

            // Valid value
            trophy.Competition = "Bowling";
            Assert.AreEqual("Bowling", trophy.Competition);

            // Invalid value: null
            Assert.ThrowsException<ArgumentException>(() => trophy.Competition = null);

            // Invalid value: too short
            Assert.ThrowsException<ArgumentException>(() => trophy.Competition = "AB");
        }

        [TestMethod()]
        public void YearPropertyTest()
        {
            var trophy = new Trophy();

            // Valid values
            trophy.Year = 1970;
            Assert.AreEqual(1970, trophy.Year);

            trophy.Year = 2025;
            Assert.AreEqual(2025, trophy.Year);

            // Invalid value: too low
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 1969);

            // Invalid value: too high
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 2026);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var trophy = new Trophy
            {
                Id = 1,
                Competition = "Bowling",
                Year = 2020
            };
            var expected = "Id: 1, Competition: Bowling, Year: 2020";
            Assert.AreEqual(expected, trophy.ToString());
        }
    }
}

