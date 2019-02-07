using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.Factory;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public class FactoryProducer {
        public static AbstractVehicleFactory GetVehicleFactory(string type) {
            return new CarFactory();           
        }
    }
}