using System;

namespace Marketo.ApiLibrary.Common.Logging
{
    public interface ILoggingService<out TLogInstance> where TLogInstance : ILogInstance
    {
        /// <summary>
        /// Log a message on Debug level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        void Debug(string message);

        /// <summary>
        /// Log message and exception on Debug level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        /// <param name="exception">An exception to be logged</param>
        void Debug(string message, Exception exception);

        /// <summary>
        /// Log a message on Info level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        void Info(string message);

        /// <summary>
        /// Log message and exception on Info level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        /// <param name="exception">An exception to be logged</param>
        void Info(string message, Exception exception);

        /// <summary>
        /// Log a message on Warn level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        void Warn(string message);

        /// <summary>
        /// Log message and exception on Warn level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        /// <param name="exception">An exception to be logged</param>
        void Warn(string message, Exception exception);

        /// <summary>
        /// Log a message on Error level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        void Error(string message);

        /// <summary>
        /// Log message and exception on Error level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        /// <param name="exception">An exception to be logged</param>
        void Error(string message, Exception exception);

        /// <summary>
        /// Log a message on Fatal level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        void Fatal(string message);

        /// <summary>
        /// Log message and exception on Fatal level
        /// </summary>
        /// <param name="message">A string message to be logged</param>
        /// <param name="exception">An exception to be logged</param>
        void Fatal(string message, Exception exception);
    }
}

