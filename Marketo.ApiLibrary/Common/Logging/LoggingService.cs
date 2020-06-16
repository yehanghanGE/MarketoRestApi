using System;
using log4net;

namespace Marketo.ApiLibrary.Common.Logging
{
    public abstract class LoggingService<TLogInstance> : ILoggingService<TLogInstance> where TLogInstance : ILogInstance, new()
    {
        protected readonly ILog logger;

        protected LoggingService()
        {
            var instance = new TLogInstance();
            this.logger = LogManager.GetLogger(typeof(TLogInstance));
        }

        public void Debug(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Debug(message);
            
        }

        public void Debug(string message, Exception exception)
        {
            if(string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Debug(message,exception);
        }

        public void Info(string message)
        {
            if(string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Info(message,exception);
        }

        public void Warn(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Warn(message);
        }

        public void Warn(string message, Exception exception)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Warn(message,exception);
        }
    

        public void Error(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Error(message,exception);
        }

        public void Fatal(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException();
            this.logger.Fatal(message,exception);
        }
    }
}
