using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    public class Seller
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }

        public Seller(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
