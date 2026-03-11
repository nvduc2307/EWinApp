namespace EWinApp.Utils.Loggers
{
    public interface ILoggingService
    {
        void Debug(object message, Exception exception = null);

        void DebugFormat(string format, params object[] args);

        void Info(object message, Exception exception = null);

        void InfoFormat(string format, params object[] args);

        void Warn(object message, Exception exception = null);

        void WarnFormat(string format, params object[] args);

        void Error(object message, Exception exception = null);

        void ErrorFormat(string format, params object[] args);

        void Fatal(object message, Exception exception = null);

        void FatalFormat(string format, params object[] args);

        bool HasConsoleAppender();
    }
}
