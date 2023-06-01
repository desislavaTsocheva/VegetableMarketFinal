using Desislava_11d_9.Controller;
using Desislava_11d_9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desislava_11d_9.View
{
    public class Display
    {
        private int closeOperationId = 6;
        public VegetableLogic vegLogic = new VegetableLogic();
        public Display()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        public void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            vegLogic.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Vegetable veg = vegLogic.Get(id);
            if (veg != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + veg.Id);
                Console.WriteLine("Name: " + veg.Name);
                Console.WriteLine("Number: " + veg.Number);
                Console.WriteLine("Price: " + veg.Price);
                Console.WriteLine("Type: " + veg.Type);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Vegetable veg = vegLogic.Get(id);
            if (veg != null)
            {
                Console.WriteLine("Enter name: ");
                veg.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                veg.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter availability: ");
                veg.TypeId = int.Parse(Console.ReadLine());
                vegLogic.Updates(id, veg);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Vegetable veg = new Vegetable();
            Console.WriteLine("Enter name: ");
            veg.Name = Console.ReadLine();
            Console.WriteLine("Enter number: ");
            veg.Number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price: ");
            veg.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter type: ");
            veg.TypeId =int.Parse(Console.ReadLine());
            vegLogic.Create(veg);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PRODUCTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var veg = vegLogic.GetAll();
            foreach (var item in veg)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Price, item.Number);
            }
        }

    }
}
