using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleApplication_AbstractFactory.AbstractFactory {
    public interface IAbstractFactory<T> {

        T Get(string type);

    }
}