using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.Factory;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public class FactoryProducer {
        public static IAbstractFactory<Vehicle> GetVehicleFactory() {
            //Simply switch concrete factory to use another one
            //In this case: SpecialVehicleFactory
            return new VehicleFactory();        
        }

        public static IAbstractFactory<Customer> GetCustomerFactory() {
            return new CustomerFactory();
        }
    }
}