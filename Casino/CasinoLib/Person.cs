using CasinoLib.TimeOnTableAllowed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib
{
    public class Person
    {
        public string Name { get; set; }
        protected ITimeOnTableAllowed TableTime { get; set; }

        public Person(ITimeOnTableAllowed tota)
        {
            TableTime = tota;
        }
    }
}
