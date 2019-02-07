using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public abstract class AbstractCustomerFactory {
        public abstract Customer GetCustomer(String type);
    }
}