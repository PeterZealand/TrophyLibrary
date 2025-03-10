using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLibrary;
using System;
using System.Collections.Generic;
using TrophyLibrary.TrophyLibrary;

namespace TrophyLibrary.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = new TrophiesRepository();
        }

        [TestMethod]
        public void GetTest()
        {
            // Test getting all trophies
            var allTrophies = repository.Get();
            Assert.AreEqual(5, allTrophies.Count);

            // Test filtering by year
            var filteredTrophies = repository.Get(filterYear: 2021);
            Assert.AreEqual(1, filteredTrophies.Count);
            Assert.AreEqual(2021, filteredTrophies[0].Year);

            // Test sorting by competition
            var sortedByCompetition = repository.Get(sortBy: "Competition");
            Assert.AreEqual("Badminton", sortedByCompetition[0].Competition);
            Assert.AreEqual("Bowling", sortedByCompetition[1].Competition);

            // Test sorting by year
            var sortedByYear = repository.Get(sortBy: "Year");
            Assert.AreEqual(1989, sortedByYear[0].Year);
            Assert.AreEqual(1999, sortedByYear[1].Year);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            // Test getting a trophy by valid ID
            var trophy = repository.GetById(1);
            Assert.IsNotNull(trophy);
            Assert.AreEqual(1, trophy.Id);

            // Test getting a trophy by invalid ID
            var invalidTrophy = repository.GetById(999);
            Assert.IsNull(invalidTrophy);
        }

        [TestMethod]
        public void AddTest()
        {
            // Test adding a new trophy
            var newTrophy = new Trophy { Competition = "Soccer", Year = 2022 };
            var addedTrophy = repository.Add(newTrophy);
            Assert.AreEqual(6, repository.Get().Count);
            Assert.AreEqual(6, addedTrophy.Id);
        }

        [TestMethod]
        public void RemoveTest()
        {
            // Test removing a trophy by valid ID
            var removedTrophy = repository.Remove(1);
            Assert.IsNotNull(removedTrophy);
            Assert.AreEqual(4, repository.Get().Count);

            // Test removing a trophy by invalid ID
            var invalidRemovedTrophy = repository.Remove(999);
            Assert.IsNull(invalidRemovedTrophy);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var updatedValues = new Trophy { Competition = "Updated Competition", Year = 2023 };

            // Test updating a trophy by valid ID
            var updatedTrophy = repository.Update(1, updatedValues);
            Assert.IsNotNull(updatedTrophy);
            Assert.AreEqual("Updated Competition", updatedTrophy.Competition);
            Assert.AreEqual(2023, updatedTrophy.Year);

            // Test updating a trophy by invalid ID
            var invalidUpdatedTrophy = repository.Update(999, updatedValues);
            Assert.IsNull(invalidUpdatedTrophy);
        }
    }
}