using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;

namespace VehicleApplication_AbstractFactory.Factory {
    public class CustomerFactory : AbstractCustomerFactory {
        public override Customer GetCustomer(string type) {
            throw new NotImplementedException();
        }
    }
}