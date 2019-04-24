using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aşağıdaki satırdaki gibi bir nesne üretemiyoruz. Yalnızca bir alt satırdaki nesneyi bir değişkene aktarabiliyoruz. Çünkü singleton deseninde bir nesneden yalnızca bir tane üretip bu nesneyi her kullanıcıya göstermemiz kullandırmamız amaçlanmıştır.
            // **CustomerManager customerMnagerNesnesi = new CustomerManager();
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }

    class CustomerManager
    {
        static CustomerManager _customerManager;
        //Eğer iki kullanıcı aynı anda istekte bulunursa bu bir çakışmaya sebep olup, 2 tana nesene oluşmasına sebep olabilir.  Bu sebepten dolayı bir lock objesi oluşturup CreateAsSingleton metodu içerisinde nesne oluşturma ilemini lock içine yapıp bu işlemi kilitlemiş olup bir thread safe oluşturulmuş olduk.
        static object _lockObject = new object();
        //Constructor' ı olan ancak dışarıdan erişilemeyen.
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            //Burada oluşturulmuş bir nesne var mı kontrolü yapılması gerekmekte. Eğer oluşturulmuş bir nesne varsa onu döndüreceğiz yok ise bir nesne oluşturmamız gerekmekte. _lockObject olayını yukarıdaki açıklama satırında yazdım.
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }

            return _customerManager;
            //Aşağıdaki satır yukarıdaki işlemin aynısıdır.
            // **return _customerManager ?? (_customerManager = new CustomerManager());
        }

        //Nesne adı ile ulaşacığımız için static yapmadık.
        public void Save()
        {
            Console.WriteLine("Saved !!");
        }
    }
}
