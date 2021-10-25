using System;
using System.Globalization;
using System.Linq;

namespace HomeTask_8_2
{
    class InputStorageFromConsole
    {
        public void StartStorage(Storage storage)
        {
            Console.WriteLine("Hello!!");
            int choice = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine(storage.PrintMenu());
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            return;

                        case 1:
                            Console.WriteLine("How many products?");
                            int length = int.Parse(Console.ReadLine());
                            for (int i = 0; i < length; i++)
                            {
                                Console.WriteLine("What type of product?\n[1]Meat\n[2]Dairy\n[3]Another\n");
                                int choice2 = int.Parse(Console.ReadLine());
                                Console.WriteLine($"{storage.Products.Count + 1}-product");
                                switch (choice2)
                                {
                                    case 1:
                                        storage.AddMeat(GetName(), GetPrice(), GetWeight(), GetExpirationdDate(), GetDateOfManufacture(), GetCategory(), GetKind());
                                        break;
                                    case 2:
                                        storage.AddDairy(GetName(), GetPrice(), GetWeight(), GetExpirationdDate(), GetDateOfManufacture());
                                        break;
                                    case 3:
                                        storage.AddProduct(GetName(), GetPrice(), GetWeight(), GetExpirationdDate(), GetDateOfManufacture());
                                        break;
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("What type of product?\n[1]Meat\n[2]Dairy\n[3]Another");
                            int choice1 = int.Parse(Console.ReadLine());
                            Console.WriteLine($"{storage.Products.Count + 1}-product");
                            switch (choice1)
                            {
                                case 1:
                                    storage.AddMeat(GetName(), GetPrice(), GetWeight(), GetExpirationdDate(), GetDateOfManufacture(), GetCategory(), GetKind());
                                    break;
                                case 2:
                                    storage.AddDairy(GetName(), GetPrice(), GetWeight(), GetExpirationdDate(), GetDateOfManufacture());
                                    break;
                                case 3:
                                    storage.AddProduct(GetName(), GetPrice(), GetWeight(), GetExpirationdDate(), GetDateOfManufacture());
                                    break;
                            }
                            break;
                        case 3:
                            if (storage.Products?.Count > 0)
                            {
                                storage.DeleteLastProduct();
                            }
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(storage.PrintCheck());
                            Console.ResetColor();
                            break;
                        case 5:
                            if (storage.Products?.Count > 0)
                            {
                                Console.WriteLine("By what percentage do you want to change the price of the product?");
                                double percent = double.Parse(Console.ReadLine());
                                storage.ChangePrice(percent);
                            }
                            break;
                        case 6:
                            Console.WriteLine("Meat Products:\n" + Check.DisplayProducts(storage.FindAllMeatProducts().Cast<Product>().ToList()));
                            break;
                        case 7:
                            storage.DeleteSpoiledDairyProducts(GetFilePath());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\nThe data was succesfully saved to a file!!\n");
                            Console.ResetColor();
                            break;
                        case 8:
                            storage.ReadDataFromFile(GetFilePath());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\nSuccesfully read data from file!!\n");
                            Console.ResetColor();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nData is not correct!!");
                    Console.ResetColor();
                }
            }
        }

        public string GetFilePath()
        {
            Console.WriteLine("Enter Path to file: ");
            return Console.ReadLine();

        }
        public string GetName()
        {
            Console.WriteLine("Enter a product name: ");
            return Console.ReadLine();
        }

        public double GetPrice()
        {
            Console.WriteLine("Enter a product price: ");
            bool result = double.TryParse(Console.ReadLine(), out double price);
            if (!result)
                throw new ArgumentException("Value must be double!!");
            return price;
        }

        public double GetWeight()
        {
            Console.WriteLine("Enter a product weight: ");
            bool result = double.TryParse(Console.ReadLine(), out double weight);
            if (!result)
                throw new ArgumentException("Value must be double!!");
            return weight;
        }

        public Category GetCategory()
        {
            Console.WriteLine("What category? \n[1]First Sort\t[2]Second Sort\t[3]High Sort");
            int choice = int.Parse(Console.ReadLine());
            Category category = 0;
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
                default: throw new ArgumentException("Category is not correct");
            }
            return category;
        }

        public Kind GetKind()
        {
            Kind kind = 0;
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
                default: throw new ArgumentException("Category is not correct");
            }
            return kind;
        }

        public int GetExpirationdDate()
        {
            Console.WriteLine("Enter Expirationd Date: ");
            bool result = int.TryParse(Console.ReadLine(), out int expirationDate);
            if (!result)
                throw new ArgumentException("Value must be integer!!");
            return expirationDate;
        }

        public DateTime GetDateOfManufacture()
        {
            Console.WriteLine("Enter Date of manufacture: ");
            bool result = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", new CultureInfo(4), DateTimeStyles.None, out DateTime dateOfManifecture);
            if (!result)
                throw new ArgumentException("Date is not correct!");
            return dateOfManifecture;
        }


    }
}
