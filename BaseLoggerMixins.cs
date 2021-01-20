//Mark Capka Assign 2 CSCD371
/*Inside of BaseLoggerMixins implement extension methods on BaseLogger for
Error, ✔
Warning, ✔
Information, and ✔
Debug. ✔
Each of these methods should take in a string for the message, as well as a parameter array of arguments for the message. 
Each of these extension methods is expected to be a shortcut for calling the BaseLogger.Log method, by automatically supplying the appropriate LogLevel. These methods should throw an exception if the BaseLogger parameter is null. 
There are a couple example unit tests to get you started.
*/


namespace Logger
{
    public static class BaseLoggerMixins
    {
              

        
       public static void Error(string message, BaseLogger baseLog, params int[] arr)

        {
            if (baseLog is null)
                throw new System.NullReferenceException("BaseLoggerMixins.Logs.Error has a null value for baseLog");

            else
                baseLog.Log(LogLevel.Error, string.Format(message, arr[0]));

        }
        public static void Warning(string message, BaseLogger baseLog, params int[] arr)

        {
            if (baseLog is null)
                throw new System.NullReferenceException("BaseLoggerMixins.Logs.Warning has a null value for baseLog");

            else
                baseLog.Log(LogLevel.Warning, string.Format(message, arr[0]));

        }
        public static void Information(string message, BaseLogger baseLog, params int[] arr)

        {
            if (baseLog is null)
                throw new System.NullReferenceException("BaseLoggerMixins.Logs.Information has a null value for baseLog");

            else
                baseLog.Log(LogLevel.Information, string.Format(message, arr[0]));

        }
        public static void Debug(string message, BaseLogger baseLog, params int[] arr)

        {
            if (baseLog is null)
                throw new System.NullReferenceException("BaseLoggerMixins.Logs.Debug has a null value for baseLog");

            else
                baseLog.Log(LogLevel.Debug, string.Format(message, arr[0]));

        }


    }
}
