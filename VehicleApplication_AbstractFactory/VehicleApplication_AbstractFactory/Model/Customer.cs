using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public interface Customer {
        int ID { get; }
        string CustomerType { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        double Income { get; set; }
    }
}
