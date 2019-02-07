using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleApplication_AbstractFactory.AbstractFactory;

namespace VehicleApplication_AbstractFactory.Model {
    public class Truck : Vehicle {

        private string Cargo { set;  get; }

        public override string Drive() {
            return string.Format("Der %s %s %s fährt mit der Fracht", Type, Brand, Model, Cargo);
        }
    }
}