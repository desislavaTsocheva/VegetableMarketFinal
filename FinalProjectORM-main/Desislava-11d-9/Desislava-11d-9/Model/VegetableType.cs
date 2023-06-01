using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desislava_11d_9.Model
{
    public class VegetableType
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        //1:M
        //Connection to db Vegetable
        public ICollection<Vegetable> Vegetables { get; set; }
    }
}
