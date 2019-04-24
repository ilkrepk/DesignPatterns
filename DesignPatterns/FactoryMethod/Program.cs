using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Burada bir iş geliştirip iş sonucunda ne döndüreceğimize karar verip, fabrikanın nasıl bir logger üreteceğine göre return işlemi yapabiliriz. Buda bizi ELogger'a bağlı kalmaktan kurtarır.
            return new ELogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Burada bir iş geliştirip iş sonucunda ne döndüreceğimize karar verip, fabrikanın nasıl bir logger üreteceğine göre return işlemi yapabiliriz. Buda bizi ELogger'a bağlı kalmaktan kurtarır.
            return new ELogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class ELogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ELogger");
        }
    }

    public class CustomerManager
    {
        ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved");

            //Aşağıdaki satırda LoggerFactory'e çok bağımlıyız. Yeri geldiğinde başka factory sınıfları kullanmamız gerekebilir.
            //ILogger logger = new LoggerFactory().CreateLogger();

            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
