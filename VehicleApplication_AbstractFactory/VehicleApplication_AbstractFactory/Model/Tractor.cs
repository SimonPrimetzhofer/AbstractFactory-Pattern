using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;

namespace VehicleApplication_AbstractFactory.Model {
    public class Tractor : Vehicle {
        public override string Drive() {
            throw new NotImplementedException();
        }
    }
}