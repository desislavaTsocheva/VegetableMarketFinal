using Desislava_11d_9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desislava_11d_9.Controller
{
    public class VegetableLogic
    {
        private VegetableContext vegContext = new VegetableContext();
        public Vegetable Get(int id)
        {
            Vegetable findVeg = vegContext.Vegetables.Find(id);
            if (findVeg != null)
            {
                vegContext.Entry(findVeg).Reference(x => x.Type).Load();

            }
            return findVeg;

        }
        public List<Vegetable> GetAll()
        {
            return vegContext.Vegetables.Include("Type").ToList();
        }
        public void Create(Vegetable veg)
        {
            vegContext.Vegetables.Add(veg);
            vegContext.SaveChanges();
        }
        public void Updates(int id, Vegetable veg)
        {
            Vegetable findVeg = vegContext.Vegetables.Find(id);
            if (findVeg == null)
            {
                return;
            }
            findVeg.Name = veg.Name;
            findVeg.Price = veg.Price;
            findVeg.Number = veg.Number;
            findVeg.Description = veg.Description;
            findVeg.Type = veg.Type;
            vegContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Vegetable findVeg = vegContext.Vegetables.Find(id);
            vegContext.Vegetables.Remove(findVeg);
            vegContext.SaveChanges();
        }
    }
}
