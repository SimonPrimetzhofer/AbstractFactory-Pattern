using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApplication_AbstractFactory.AbstractFactory;

namespace VehicleApplication_AbstractFactory.Model {
    public class PrivateCustomer : Customer {
        public int ID { get; }
        public string CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }


    }
}
