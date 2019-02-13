using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;
using VehicleApplication_AbstractFactory.Model;

namespace VehicleApplication_AbstractFactory.Model {
    public class Car : Vehicle {
        public override string Drive() {
            return string.Format("Der {0} {1} {2} fährt mit {3} Personen", Type, Brand, Model, Seats);
        }
    }
}