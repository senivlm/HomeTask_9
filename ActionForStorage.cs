using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_8_2
{
    static class ActionForStorage
    {
        static public void LogWrongInput(string path, string wrongLine, int paramsCounter)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                string result = "\n\nTime adding product: " + DateTime.Now;
                result += "\nWrong input in line:\n " + wrongLine;
                switch (paramsCounter)
                {
                    case 0:
                        result += "Wrong type";
                        break;
                    case 1:
                        result += "Wrong weight";
                        break;
                    case 2:
                        result += "Wrong price";
                        break;
                    case 3:
                        result += "Wrong Expiration Date";
                        break;
                    case 4:
                        result += "Wrong date Of Manufacture";
                        break;
                    case 5:
                        result += "Wrong Category of Meat";
                        break;
                    case 6:
                        result += "Wrong Kind of Meat";
                        break;
                }

                file.WriteLine(result.ToString());
            }

        }

        static public void CorrectInputProduct(Storage storage, string wrongLine)
        {
            Console.WriteLine($"\n\nMistake in line\n {wrongLine}\n Enter new product Name: ");
            string newName = Console.ReadLine();
            double price = 0;
            double weight = 0;
            int expirationDate = 0;
            DateTime dateOfManifecture;

            while (true)
            {
                Console.WriteLine("Enter new price: ");
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new weight: ");
                if (double.TryParse(Console.ReadLine(), out weight))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new expiration Date: ");
                if (int.TryParse(Console.ReadLine(), out expirationDate))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new date Of Manifecture: ");
                if (DateTime.TryParseExact(Console.ReadLine().Substring(0, 10), "dd.MM.yyyy", new CultureInfo(3), DateTimeStyles.None, out dateOfManifecture))
                {
                    break;
                }
            }

            storage.AddProduct(newName, price, weight, expirationDate, dateOfManifecture);
        }

        static public void CorrectInputDairy(Storage storage, string wrongLine)
        {
            Console.WriteLine($"\n\nMistake in line\n {wrongLine}\n Enter new product Name: ");
            string newName = Console.ReadLine();
            double price = 0;
            double weight = 0;
            int expirationDate = 0;
            DateTime dateOfManifecture;

            while (true)
            {
                Console.WriteLine("Enter new price: ");
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new weight: ");
                if (double.TryParse(Console.ReadLine(), out weight))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new expiration Date: ");
                if (int.TryParse(Console.ReadLine(), out expirationDate))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new date Of Manifecture: ");
                if (DateTime.TryParseExact(Console.ReadLine().Substring(0, 10), "dd.MM.yyyy", new CultureInfo(3), DateTimeStyles.None, out dateOfManifecture))
                {
                    break;
                }
            }

            storage.AddDairy(newName, price, weight, expirationDate, dateOfManifecture);
        }

        static public void CorrectInputMeat(Storage storage, string wrongLine)
        {
            Console.WriteLine($"\n\nMistake in line\n {wrongLine}\n Enter new product Name: ");
            string newName = Console.ReadLine();
            double price = 0;
            double weight = 0;
            int expirationDate = 0;
            DateTime dateOfManifecture;
            Category category = 0;
            Kind kind = 0;
//Можна обмежувати кількість спроб
            while (true)
            {
                Console.WriteLine("Enter new price: ");
                if (double.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new weight: ");
                if (double.TryParse(Console.ReadLine(), out weight))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new expiration Date: ");
                if (int.TryParse(Console.ReadLine(), out expirationDate))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Enter new date Of Manifecture: ");
                if (DateTime.TryParseExact(Console.ReadLine().Substring(0, 10), "dd.MM.yyyy", new CultureInfo(3), DateTimeStyles.None, out dateOfManifecture))
                {
                    break;
                }
            }
            while (category == 0)
            {
                Console.WriteLine("What category? \n[1]First Sort\t[2]Second Sort\t[3]High Sort");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        category = Category.FirstSort;
                        break;
                    case 2:
                        category = Category.SecondSort;
                        break;
                    case 3:
                        category = Category.HighSort;
                        break;
                }
            }

            while (kind == 0)
            {
                Console.WriteLine("What kind of meat? \n[1]Mutton\t[2]Veal\n[3]Pork\t\t[4]Chicken");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        kind = Kind.Mutton;
                        break;
                    case 2:
                        kind = Kind.Veal;
                        break;
                    case 3:
                        kind = Kind.Pork;
                        break;
                    case 4:
                        kind = Kind.Chicken;
                        break;
                }
            }

            storage.AddMeat(newName, price, weight, expirationDate, dateOfManifecture, category, kind);
        }
// для того, щоб методу передавати список продуктів, його треба розінкапсулювати з екземпляру класу. Тому ,краще в обробнику мати екземпляр Storagе, а в ньому передбачити метод вилучення.
        static public void RemoveSpoiledProducts(List<Product> products, string path)
        {
            List<Product> spoiledProducts = new List<Product>();

            spoiledProducts = products.FindAll(i => i.IsSpoiledProduct());
            foreach (var product in spoiledProducts)
            {
                products.Remove(product);
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("\nSpoiled Products:\n");
                foreach (var product in spoiledProducts)
                {
                    writer.WriteLine(product);
                }
            }

        }
    }
}
