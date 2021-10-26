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
        
        static void Main(string[] args)
        {

            try
            {
                //D:/Users/vital/source/repos/HomeTask2/input.txt
                var Input = new InputStorageFromConsole();

                Storage storage1 = new Storage();

                storage1.OnAdd += (i) => Console.WriteLine(i);

                storage1.OnWrongInput += ActionForStorage.LogWrongInput;

                storage1.OnCorrectWrongInputForMeat += ActionForStorage.CorrectInputMeat;

                storage1.OnCorrectWrongInputForProduct += ActionForStorage.CorrectInputProduct;

                storage1.OnCorrectWrongInputForDairy += ActionForStorage.CorrectInputDairy;

                storage1.OnRemoveSpoiledProducts += ActionForStorage.RemoveSpoiledProducts;

                Input.StartStorage(storage1);

                Console.WriteLine(storage1.PrintCheck());

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
