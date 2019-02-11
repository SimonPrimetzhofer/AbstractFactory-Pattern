using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public interface AbstractVehicleFactory {
        Vehicle GetVehicle(string type);
        
    }
}