using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;

namespace VehicleApplication_AbstractFactory.Model {
    public class Truck : Vehicle {

        public override string Drive() {
            return string.Format("Der {0} {1} {2} fährt mit {3} KW", Type, Brand, Model, Kilowatt);
        }
    }
}