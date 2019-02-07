using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;
using VehicleApplication_AbstractFactory.Model;

namespace VehicleApplication_AbstractFactory.Model {
    public class Car : Vehicle {
        public override string Drive() {
            return string.Format("Der %s %s %s fährt mit %d Personen", Type, Brand, Model, Seats);
        }
    }
}