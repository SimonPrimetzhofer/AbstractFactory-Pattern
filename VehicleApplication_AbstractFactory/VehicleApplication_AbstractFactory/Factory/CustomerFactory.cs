using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;
using VehicleApplication_AbstractFactory.Model;

namespace VehicleApplication_AbstractFactory.Factory {
    public class CustomerFactory : AbstractCustomerFactory {
        public Customer GetCustomer(string type) {
            Customer c = null;

            switch (type) {
                case "Privatperson": c = new PrivateCustomer(); break;
                case "Firma": c = new Company(); break;
            }

            return c;
        }
    }
}