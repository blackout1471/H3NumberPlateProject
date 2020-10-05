using NLog;
using NumberPlateApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPlateApi.LoggerService
{
    /// <summary>
    /// Class for the logger manager
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creates a debug logger message
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Creates a log error message
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Creates a log info message
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Creates a log warning message
        /// </summary>
        /// <param name="message"></param>
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
