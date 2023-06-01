using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Desislava_11d_9.Model
{
    public class Vegetable
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        //M:1
        public int TypeId { get; set; }
        //connection to db VegetableType
        public VegetableType Type { get; set; }
    }
}
