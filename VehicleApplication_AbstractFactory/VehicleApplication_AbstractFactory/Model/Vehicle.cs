using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public abstract class Vehicle {
        protected int ID { get; }
        protected string Type { get; set; }
        protected string Brand { get; set; }
        protected string Model { get; set; }
        protected int Kilowatt { get; set; }
        protected int Seats { get; set; }
        protected bool Preowned { get; set; }
        protected Customer Owner { get; set; }
        public abstract string Drive();

        public string SellTo(Customer NewOwner) {

            string message = "";

            if (!Owner.Equals(NewOwner)) {
                Owner = NewOwner;
                message = string.Format("%s %s %s was sold to %s %s", Type, Brand, Model, Owner.FirstName, Owner.LastName);
            } else message = string.Format("%s %s already owns this vehicle!");

            return message;
        }

        public override bool Equals(object o) {
            Vehicle other = (Vehicle)o;

            return ID == other.ID;
        }

        public override int GetHashCode() {
            var hashCode = 673475437;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Brand);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 + Kilowatt.GetHashCode();
            hashCode = hashCode * -1521134295 + Seats.GetHashCode();
            hashCode = hashCode * -1521134295 + Preowned.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(Owner);
            return hashCode;
        }
    }
}
