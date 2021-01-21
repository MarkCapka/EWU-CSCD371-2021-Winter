using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        private static readonly string filePath = "tester.txt";

        [TestMethod]
        public void ConfigureFileLogger_newFilePath_ReturnsFileLogger()
        {
            //Arrrange
            var logger = new LogFactory();
            string filePath = logger.FilePath;
            logger.ConfigureFileLogger(filePath);
            //Act

            //Assert


            Assert.AreEqual("tester.txt",filePath);


        }


        [TestMethod]
        public void CreateLogger_NewFileLogger_CorrectClassName()
        {
            //Arrange
           var logger = new LogFactory();

            //Act
            string className = "FileLogger";   
            logger.CreateLogger(className);
         

            //Assert
            Assert.AreEqual(className, logger.ClassName);

        }




        //no need for getter test

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateLogger_nullRef_throwsExceptionWhenNull()
        {
            //Arrange
#pragma warning disable CS0219 // Variable is assigned but its value is never used

            LogFactory logger = null;  //note this is suppresesed since we are trying to get it to throw null here 


#pragma warning restore CS0219 // Variable is assigned but its value is never used


            //Act
            logger.CreateLogger(null);

            //Assert
        }


    }






}
