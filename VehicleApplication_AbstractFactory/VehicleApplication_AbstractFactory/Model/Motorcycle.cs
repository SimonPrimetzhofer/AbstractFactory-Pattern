using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;

namespace VehicleApplication_AbstractFactory.Model {
    public class Motorcycle : Vehicle {
        public override string Drive() {

            return string.Format("Das {0} {1} {2} hat {3} Sitze", Type, Brand, Model, Seats);
        }
    }
}