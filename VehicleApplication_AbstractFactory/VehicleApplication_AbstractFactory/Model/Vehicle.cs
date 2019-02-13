using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public abstract class Vehicle {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Kilowatt { get; set; }
        public int Seats { get; set; }
        public bool Preowned { get; set; }
        public Customer Owner { get; set; }
        public abstract string Drive();

        public string SellTo(Customer NewOwner) {

            string message = "";

            if (!Owner.Equals(NewOwner)) {
                Owner = NewOwner;
                message = string.Format("{0} {1} {2} was sold to {3} {4}", Type, Brand, Model, Owner.FirstName, Owner.LastName);
            } else message = string.Format("{0} {1} already owns this vehicle!", Owner.FirstName, Owner.LastName);

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
