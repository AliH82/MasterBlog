using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Domian
{
    public class BaseDomian
    {
        public int Id { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public BaseDomian()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
