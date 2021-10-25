
using System;
using System.Globalization;

namespace HomeTask_8_2
{
    class DairyProduct : Product
    {

        public new event PrintIncorrect OnWrongInput;
        public override void ChangePrice(double percent)
        {
            if (ExpirationDate < 0)
            {
                Price = 0;
            }
            else
            {
                Price += (percent + ExpirationDate * 5) * Price / 100;
            }
        }

        public new bool TryParse(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            string[] data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length != 5)
                return false;


            Name = data[0];
            double weight;
            double price;

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

            this.Weight = weight;
            this.Price = price;
            this.ExpirationDate = expirationDate;
            this.DateOfManufacture = dateOfManifecture;
            return true;
        }

        public override string ToString()
        {
            return "\nDairy Product\n" + base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && Equals(obj as DairyProduct);
        }

        public bool Equals(DairyProduct other)
        {
            return other != null && ExpirationDate == other.ExpirationDate;
        }

        public DairyProduct(string name, double weight, double price, int expirationDate, DateTime dateOfManifecture)
            : base(name, weight, price, expirationDate, dateOfManifecture)
        {
        }

        public DairyProduct(Product product) : base(product)
        {
        }
        public DairyProduct()
        {

        }
    }
}
