using System;
using System.Globalization;

namespace HomeTask_8_2
{
    enum Category
    {
        SecondSort = 5,
        FirstSort = 10,
        HighSort = 15
    }

    enum Kind
    {
        Mutton = 1,
        Veal,
        Pork,
        Chicken
    }
    class Meat : Product
    {
        public new event PrintIncorrect OnWrongInput;
        public Category Category { get; set; }

        public Kind Kind { get; set; }

        public Meat(string name, double weight, double price, int expirationDate, DateTime dateOfManufacture, Category category, Kind kind)
            : base(name, weight, price, expirationDate, dateOfManufacture)
        {
            Category = category;

            Kind = kind;
        }

        public Meat(Product product, Category category, Kind kind) : base(product)
        {
            Category = category;

            Kind = kind;
        }

        public new bool TryParse(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            string[] data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length != 7)
                return false;

            string name;
            double weight;
            double price;
            Category category;
            Kind kind;
            name = data[0];

            
            bool result = double.TryParse(data[1], out weight);
            if (!result)
            {
                OnWrongInput?.Invoke(@"D:\Users\vital\source\repos\HomeTask2\log.txt", line, 1);
                return false;
            }
            result = double.TryParse(data[2], out price);
            if (!result)
            {
                OnWrongInput?.Invoke(@"D:\Users\vital\source\repos\HomeTask2\log.txt", line, 2);
                return false;
            }
            result = int.TryParse(data[3], out int expirationDate);
            if (!result)
            {
                OnWrongInput?.Invoke(@"D:\Users\vital\source\repos\HomeTask2\log.txt", line, 3);
                return false;
            }
            result = DateTime.TryParseExact(data[4].Substring(0, 10), "dd.MM.yyyy", new CultureInfo(3), DateTimeStyles.None, out DateTime dateOfManifecture);
            if (!result)
            {
                OnWrongInput?.Invoke(@"D:\Users\vital\source\repos\HomeTask2\log.txt", line, 4);
                return false;
            }
            switch (data[5])
            {
                case "First":
                    category = Category.FirstSort;
                    break;
                case "Second":
                    category = Category.SecondSort;
                    break;
                case "High":
                    category = Category.HighSort;
                    break;
                default:
                    OnWrongInput?.Invoke(@"D:\Users\vital\source\repos\HomeTask2\log.txt", line, 5);
                    return false;
            }

            switch (data[6].Trim('\r'))
            {
                case "Mutton":
                    kind = Kind.Mutton;
                    break;
                case "Veal":
                    kind = Kind.Veal;
                    break;
                case "Pork":
                    kind = Kind.Pork;
                    break;
                case "Chicken":
                    kind = Kind.Chicken;
                    break;
                default:
                    OnWrongInput?.Invoke(@"D:\Users\vital\source\repos\HomeTask2\log.txt", line, 6);
                    return false;
            }
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
            this.ExpirationDate = expirationDate;
            this.DateOfManufacture = dateOfManifecture;
            this.Category = category;
            this.Kind = kind;
            return true;

        }
        public override void ChangePrice(double percent)
        {
            base.ChangePrice(percent);
            Price += (double)Category * Price / 100;
        }

        public override string ToString()
        {
            return "\n\nMeat\n" + base.ToString() + $"Category: {Category}\nKind: {Kind}\n";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && Equals(obj as Meat);
        }

        public bool Equals(Meat other)
        {
            return other != null && Category == other.Category
                && Kind == other.Kind;
        }
        public Meat()
        {

        }
    }
}
