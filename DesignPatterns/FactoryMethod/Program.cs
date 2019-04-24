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
            CustomerManager customerManager = new CustomerManager();
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

    public interface ILoggerFactory
    {

    }

    public interface ILogger
    {
        void Log();
    }

    //ELogger daki E soyadım olan Epik'in esi, kafa karıştırmasın.
    public class ELogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ELogger");
        }
    }

    public class CustomerManager
    {
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = new LoggerFactory().CreateLogger();
            logger.Log();
        }
    }
}
