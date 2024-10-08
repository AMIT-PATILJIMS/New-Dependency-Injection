namespace Lis
{
    public interface IErrorLogger
    {
        void LogMessage(Exception ex);
    }

    public class FileLogger : IErrorLogger
    {
        public void LogMessage(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public class EventViewerLogger : IErrorLogger
    {
        public void LogMessage(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public class Operation
    {
        /*
         * previously our _logger object is dependent on FileLogger()
         * IErrorLogger _logger = new FileLogger();
         */
        //Now our logger neither dependent on FileLogger nor on EventViewerLogger
        IErrorLogger _logger;
        public Operation(IErrorLogger logger)
        {
            _logger = logger;
        }
        /* Now this class is following Open Closed principle
         * Open for extension but closed for modification.
         */
        public void Add() {
            try
            {
                int x = 3;
                int y = 6;

                Console.WriteLine(x + y);
            }
            catch (Exception ex){
                _logger.LogMessage(ex);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //here we actually inject the dependency in our startup class

            Operation obj = new Operation(new EventViewerLogger());

            obj.Add();
        }
    }
}
