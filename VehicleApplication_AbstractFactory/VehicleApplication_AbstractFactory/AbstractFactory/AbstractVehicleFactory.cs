using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public abstract class AbstractVehicleFactory {
        public abstract Vehicle GetVehicle(String type);
        
    }
}