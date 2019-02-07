using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.Factory;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public class FactoryProducer {
        public static AbstractVehicleFactory GetVehicleFactory(string type) {
            AbstractVehicleFactory avf = null;

            switch(type) {
                case "PKW": avf = new CarFactory(); break;
                //case "LKW": avf = new 
                //case "Motorrad": 
                //case "Traktor": 
            }

            return avf;           
        }

        public static AbstractCustomerFactory GetCustomerFactory(string type) {
            AbstractCustomerFactory acf = null;

            switch(type) {
                //case "Privatperson": acf = new 
                //case "Firma": 
            }

            return acf;
        }
    }
}