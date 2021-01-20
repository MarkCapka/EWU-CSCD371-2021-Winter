using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


/*Create a FileLogger that derives from BaseLogger. It should take in a path to a file to write the log message to.
  * When its Log method is called, it should append messages on their own line in the file. The output should include all of the following:
 The current date/time ✔
 The name of the class that created the logger ✔
 The log level ✔
 The message ✔
 The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"*/





namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string ClassName { get; set; }
        public string FilePath { get; set; }
     


        public FileLogger(string filePath)
        {
            if (FilePath is null)
                throw new ArgumentNullException("Error in FileLogger(FilePath) with null FilePath");
                      
            ClassName = "FileLogger";
            FilePath = filePath;

        }

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter append = new StreamWriter(FilePath);

            string fullDateTime = DateTime.Now.ToString("MMM-dd-yyyy hh-mm-tt");
            append.WriteLine("Current Date & Time: " + fullDateTime);
            append.WriteLine("Class Name: " + ClassName);
            append.WriteLine("Log Level: " + nameof(logLevel));   /* Use the nameof() operator when identifying the class name to the logger ✔*/
            append.WriteLine("Message: " + message);
            append.Flush();             


        }
    }
}
