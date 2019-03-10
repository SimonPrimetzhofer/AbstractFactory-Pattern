using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;
using VehicleApplication_AbstractFactory.Model;

namespace VehicleApplication_AbstractFactory.Factory {
    public class SpecialVehicleFactory : IAbstractFactory<Vehicle> {
        
        public Vehicle Get(string type) {
            Vehicle v = null;

            switch(type) {
                case "PKW": v = new Car(); break;
                case "LKW": v = new Truck(); break;
                case "Motorrad": v = new Motorcycle(); break;
                case "Traktor": v = new Tractor(); break;
            }

            return v;
        }
    }
}