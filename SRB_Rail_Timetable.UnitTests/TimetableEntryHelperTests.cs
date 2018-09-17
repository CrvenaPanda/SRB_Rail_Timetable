using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRB_Rail_Timetable.Logic;
using SRB_Rail_Timetable.Models;

namespace SRB_Rail_Timetable.UnitTests
{
    [TestClass]
    public class TimetableEntryHelperTests
    {
        #region IsTimeSooner

        [TestMethod]
        public void IsTimeSooner_IsSooner_ReturnsTrue()
        {
            // Arrange
            var time = "11:25";
            var comparedToTime = "16:05";

            // Act
            var result = TimetableEntryHelper.IsTimeSooner(time, comparedToTime);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTimeSooner_IsSoonerSameHour_ReturnsTrue()
        {
            // Arrange
            var time = "11:25";
            var comparedToTime = "11:45";

            // Act
            var result = TimetableEntryHelper.IsTimeSooner(time, comparedToTime);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTimeSooner_IsNotSooner_ReturnsFalse()
        {
            // Arrange
            var time = "11:25";
            var comparedToTime = "02:50";

            // Act
            var result = TimetableEntryHelper.IsTimeSooner(time, comparedToTime);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTimeSooner_IsNotSoonerSameHour_ReturnsFalse()
        {
            // Arrange
            var time = "11:25";
            var comparedToTime = "11:11";

            // Act
            var result = TimetableEntryHelper.IsTimeSooner(time, comparedToTime);

            // Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region ExtractTimeFromString

        [TestMethod]
        public void ExtractTimeFromString_HoursAndMinutes()
        {
            // Arrange
            var time = "2:30";
            var expected = TimeSpan.FromMinutes(150);

            // Act
            var result = TimetableEntryHelper.ExtractTimeFromString(time);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtractTimeFromString_Hours()
        {
            // Arrange
            var time = "2:00";
            var expected = TimeSpan.FromMinutes(120);

            // Act
            var result = TimetableEntryHelper.ExtractTimeFromString(time);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtractTimeFromString_Minutes()
        {
            // Arrange
            var time = "00:30";
            var expected = TimeSpan.FromMinutes(30);

            // Act
            var result = TimetableEntryHelper.ExtractTimeFromString(time);

            // Assert
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region MergeDateWithStringTime

        [TestMethod]
        public void MergeDateWithStringTime_NormalCase()
        {
            // Arrange
            var date = new DateTime(1, 1, 1);
            var time = "20:30";
            var expected = new DateTime(1, 1, 1, 20, 30, 0);

            // Act
            var result = TimetableEntryHelper.MergeDateWithStringTime(date, time);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MergeDateWithStringTime_NextDay()
        {
            // Arrange
            var date = new DateTime(1, 1, 1);
            var time = "20:30";
            var expected = new DateTime(1, 1, 2, 20, 30, 0);

            // Act
            var result = TimetableEntryHelper.MergeDateWithStringTime(date, time, true);

            // Assert
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region GetTarrifes // TODO: write unit tests for GetTarrifes

        [TestMethod]
        public void GetTarrifes_ListIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var list = new List<string>();

            // Assert
            Assert.ThrowsException<ArgumentException>(() => TimetableEntryHelper.GetTarrifes(list));
        }

        // TODO: one item

        // TODO: some items

        // TODO: all items

        #endregion
    }
}
