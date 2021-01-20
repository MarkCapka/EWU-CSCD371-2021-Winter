using System;
using System.IO;




namespace Logger
{
    
    public class LogFactory
    {
        public string ClassName { get; set; } = "LogFactory"; //name that will be used when referring to creator. 
        public string? FilePath { get; set; } //declared as nullable
       

        public BaseLogger CreateLogger(string className)  //nullable string passed in 
        {
            BaseLogger? logger = null; //declared as nullable      
            
            string filePath = GetFilePath();

            ConfigureFileLogger(filePath);

         FileLogger fileLogger = new FileLogger(filePath);
               
                logger = fileLogger;            

             if (logger is null)
                throw new NullReferenceException("Logger cannot be instantiated as it is null");


            else
                return logger;
           
           
        }
        //The LogFactory should be updated with a new method ConfigureFileLogger. 
        public void ConfigureFileLogger(string filePath)
        {
            FilePath = GetFilePath();


        }
        //It should use this when instantiating a new FileLogger in its CreateLogger method.

        private static string GetFilePath()
        {
            if (File.Exists("tester.txt"))
            {
                string fileName = "tester.txt";
                return fileName;
            }

            else 
                throw new FileNotFoundException("filePath cannot be found in GetFilePath()");

        }
    
    }


}
