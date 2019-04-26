using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManger customerManager = new CustomerManger();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    internal interface ICaching
    {
        void Cache();
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }
    class Caching: ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    class Authorize: IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    class CustomerManger
    {
        CrossCuttingConcernsFacade _concerns;
        public CustomerManger()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
