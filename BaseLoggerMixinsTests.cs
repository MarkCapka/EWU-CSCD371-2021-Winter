using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.IO;


namespace Logger.Tests
{


    [TestClass]
    public class BaseLoggerMixinsTests
    {

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null, null, null);

            // Assert

        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
           BaseLoggerMixins.Error(logger, "Error Message {0}", 9);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Error Message 9", logger.LoggedMessages[0].Message);
        }

     

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Warning(null , null, null);

            // Assert

        }


        [TestMethod]
        public void Warning_WithData_LogMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            BaseLoggerMixins.Warning(logger, "Warning Message {0}", 11);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Warning Message 11", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Information(null, null, null);

            // Assert

        }

        [TestMethod]
        public void Information_WithData_LogMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            BaseLoggerMixins.Information(logger, "Information Message {0}", 24);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Information Message 24", logger.LoggedMessages[0].Message);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Debug( null, null, null);

            // Assert

        }
        
        [TestMethod]
        public void Debug_WithData_LogMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Debug("Debug Message {0}", 12);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Debug Message 12", logger.LoggedMessages[0].Message);
        }


    }

     public class TestLogger : BaseLogger
    {

        public override string ClassName { get; set; } = "FileLogger";

        public List<(LogLevel LogLevel, string Message)>
            LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }

       
    }
