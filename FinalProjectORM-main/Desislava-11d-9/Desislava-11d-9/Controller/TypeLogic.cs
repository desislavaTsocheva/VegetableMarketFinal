using Desislava_11d_9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desislava_11d_9.Controller
{
    public class TypeLogic
    {
        private VegetableContext _vegContext = new VegetableContext();

        public List<VegetableType> GetAllTypes()
        {
            return _vegContext.VegetablesTypes.ToList();
        }
        public string GetTypeById(int id)
        {
            return _vegContext.VegetablesTypes.Find(id).Name;
        }
    }
}
