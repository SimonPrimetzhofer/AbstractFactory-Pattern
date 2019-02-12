using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;

namespace VehicleApplication_AbstractFactory.Model {
    public class Tractor : Vehicle {
        public override string Drive() {
            return String.Format("Der {0} {1} {2} is a Traktor", Type, Model, Brand);
        }
    }
}