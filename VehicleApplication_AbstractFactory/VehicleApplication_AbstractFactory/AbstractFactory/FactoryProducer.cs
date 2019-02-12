using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.Factory;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public class FactoryProducer {
        public static AbstractVehicleFactory GetVehicleFactory() {
            return new VehicleFactory();        
        }

        public static AbstractCustomerFactory GetCustomerFactory() {
            return new CustomerFactory();
        }
    }
}