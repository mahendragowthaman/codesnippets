using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResxTest
{
    public class Car
    {
        private static Car carInstance;
        public string name { get; private set; }
        public string brand { get; private set; }

        public Engine engine { get; private set; }

        private Car()
        {
            brand = "Maruti";
            engine = new Engine()
            {
                engineNumber = "jhjdshjd"
            };
        }

        public static Car getInstance()
        {
            //For private set.
            if (carInstance == null)
            {
                carInstance = new Car();
                carInstance.name = "baleno";
                carInstance.brand = "Maruti";
                carInstance.engine = new Engine()
                {
                    engineNumber = "jhjdshjd"
                };
            }

            return carInstance;
        }

        public class Engine
        {
            public string engineNumber { get; set; }
        }
    }


}
