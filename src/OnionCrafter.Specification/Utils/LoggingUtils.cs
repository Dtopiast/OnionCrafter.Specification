using Microsoft.Extensions.Logging;

namespace OnionCrafter.Specification.Utils
{
    public static class LoggingUtils
    {
        public static void CreateInformationOrErrorLog(this ILogger logger, bool result, string successfullMessage, string errorMessage, string? obj = null, params object?[] args)
        {
            //usa string builder
            if (result)
            {
                if (obj != null)
                    successfullMessage = obj + " " + successfullMessage;
                logger.LogInformation(successfullMessage, args);
            }
            else
            {
                if (obj != null)
                    errorMessage = obj + " " + errorMessage;
                logger.LogError(errorMessage, args);
            }
        }
    }
}