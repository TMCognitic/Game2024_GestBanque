using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Autre
{
    public struct Celsius
    {
        public static implicit operator Fahrenheit(Celsius celsius)
        {
            return new Fahrenheit() { Temperature = (celsius.Temperature * 1.8) + 32 };
        }

        public double Temperature { get; set; }
    }
}
