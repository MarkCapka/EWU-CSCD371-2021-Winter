using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        private readonly string filePath = "tester.txt";

        //Working now! 
        [TestMethod]
        public void FileLogger_logFactory_AssignPathAndClass()
        {

            //arrange            
            var logFactory = new LogFactory();

            //act
            FileLogger logger = (FileLogger)logFactory.CreateLogger("FileLogger");
           
            string filePath = logger.FilePath;
            string className = logger.ClassName;

            //assert
            Assert.AreEqual("tester.txt", filePath);
            Assert.AreEqual("FileLogger", className);



        }

        [TestMethod]
        public void FileLogger_LogFormat_IsCorrect()
        {
            //Arrange

            FileLogger logger = new FileLogger(filePath);
           
           
            String className = logger.ClassName;
            string fullDateTime = DateTime.Now.ToString("MMM-dd-yyyy hh-mm-tt");
     
            //Act
            logger.Log(LogLevel.Warning, "Message: ");

            string[]? lineIndex = File.ReadAllLines(filePath);


            //Assert
            Assert.AreEqual("Current Date & Time: " + fullDateTime, lineIndex[0]);
            Assert.AreEqual("Class Name: " + className, lineIndex[1]);
            Assert.AreEqual("Log Level: " + nameof(LogLevel.Warning), lineIndex[2]);
            Assert.AreEqual("Message: " , lineIndex[3]);

        }
    }
}
