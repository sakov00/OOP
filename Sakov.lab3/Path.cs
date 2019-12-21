using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakov.lab3
{
    public partial class Bus
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Bus m = obj as Bus;
            if (m as Bus == null)
                return false;
            return m.NameBus == this.NameBus
                && m.Driver == this.Driver
                && m.NumberBus == this.NumberBus
                && m.NumberWay == this.NumberWay
                && m.TypeBus == this.TypeBus
                && m.BegingBusYear == this.BegingBusYear
                && m.RunBus == this.RunBus;
        }
        public override int GetHashCode()
        {
            int hash = 269;
            hash = string.IsNullOrEmpty(NameBus) ? 0 : NameBus.GetHashCode();
            hash = (hash * 47) + NumberBus.GetHashCode();
            return hash;
        }
        public override string ToString()
        {
            return NameBus + " " + Driver + " " + NumberBus + " " + NumberWay + " " + TypeBus + " " + BegingBusYear + " " + TypeBus;
    }
    }
}

