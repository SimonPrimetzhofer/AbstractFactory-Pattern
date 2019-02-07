using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;
using VehicleApplication_AbstractFactory.Model;

namespace VehicleApplication_AbstractFactory.Factory {
    public class CarFactory : AbstractVehicleFactory {
        public override Vehicle GetVehicle() {
            return new Car();
        }
    }
}