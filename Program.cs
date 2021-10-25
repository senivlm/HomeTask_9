using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeTask_8_2
{
     delegate void PrintMessageHandler(string message);
     delegate void PrintIncorrect(string path, string wrongLine, int paramCounter);
     delegate void ModifyInput(Storage storage, string wrongLine);
     delegate void RemoveSpoiledProductsAndWriteInLog(List<Product> products, string path);

    class Program
    {
        static void LogWrongInput(string path, string wrongLine, int paramsCounter)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                string result = "\n\nTime adding product: "+DateTime.Now;
                result+="\nWrong input in line:\n " + wrongLine;
                switch (paramsCounter)
                {
                    case 0:
                        result += "Wrong type";
                        break;
                    case 1:
                        result += "Wrong weight";
                        break;
                    case 2:
                        result+="Wrong price";
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

        static void CorrectInputProduct(Storage storage, string wrongLine)
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

        static void CorrectInputDairy(Storage storage, string wrongLine)
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

        static void CorrectInputMeat(Storage storage, string wrongLine)
        {
            Console.WriteLine($"\n\nMistake in line\n {wrongLine}\n Enter new product Name: ");
            string newName = Console.ReadLine();
            double price = 0;
            double weight = 0;
            int expirationDate = 0;
            DateTime dateOfManifecture;
            Category category = 0;
            Kind kind=0;

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
            while (category==0)
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

            while(kind == 0)
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

            storage.AddMeat(newName, price, weight, expirationDate, dateOfManifecture,category,kind);
        }

        static void RemoveSpoiledProducts(List<Product> products, string path)
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

            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine("\nSpoiled Products:\n");
                foreach (var product in spoiledProducts)
                {
                   writer.WriteLine(product);
                }
            }

        }
        static void Main(string[] args)
        {

            try
            {
                //D:/Users/vital/source/repos/HomeTask2/input.txt
                var Input = new InputStorageFromConsole();

                Storage storage1 = new Storage();
                storage1.OnAdd += (i) => Console.WriteLine(i);
                storage1.OnWrongInput += LogWrongInput;
                storage1.OnCorrectWrongInputForMeat += CorrectInputMeat;
                storage1.OnCorrectWrongInputForProduct += CorrectInputProduct;
                storage1.OnCorrectWrongInputForDairy += CorrectInputDairy;
                storage1.OnRemoveSpoiledProducts += RemoveSpoiledProducts;
                Input.StartStorage(storage1);

                Console.WriteLine(storage1.PrintCheck());



                Storage storage2 = new Storage();
                Input.StartStorage(storage2);

                Console.WriteLine("\n\nJoint Product\n\n");

                foreach (var item in storage1.GetJointProducts(storage2))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n\nJoint Product\n\n");

                foreach (var item in storage1.GetProductsNotContainsOther(storage2))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\n\nJoint Product\n\n");

                foreach (var item in storage1.GetDifferentProducts(storage2))
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nEnd program\n");
            }

        }
    }
}
