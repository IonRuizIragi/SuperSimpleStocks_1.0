using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public class SuperSimpleStocks
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo op;
            
            do
            {
                Console.Clear(); 
                Console.WriteLine("\nSuperSimpleStocks Application - by Ion Ruiz Iragui\n");
                ShowAll();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t[A] Calculate the dividend yield\n");
                Console.Write("\t[B] Calculate the P/E Ratio\n");
                Console.Write("\t[C] Record a trade\n");
                Console.Write("\t[D]. Calculate Stock Price based on trades recorded in the last X\n");
                Console.Write("\t[E]. Calculate the GBCE All Share Index\n");
                Console.Write("\t[Esc] Exit\t\n\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Select an option...");
                op = Console.ReadKey(true);
                
                switch (op.Key)
                {
                    case ConsoleKey.A:
                        Console.Clear(); 
                        Console.WriteLine("\nSuperSimpleStocks Application - by Ion Ruiz Iragui\n\n");
                        ShowAll();
                        Console.WriteLine("[A]. Calculate the dividend yield: Type the SymbolCode:");
                        String choice1 = Console.ReadLine();                 
                        Console.WriteLine("\nThe dividend yield of " +
                            choice1 + ": " + BLL.calculateDividendYield(choice1));
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.B:
                        Console.Clear(); 
                        Console.WriteLine("\nSuperSimpleStocks Application - by Ion Ruiz Iragui\n\n");
                        ShowAll();
                        Console.WriteLine("[B]. Calculate the P/E Ratio");
                        String choice2 = Console.ReadLine();                 
                        Console.WriteLine("\nThe dividend yield of " +
                            choice2 + ": " + BLL.PERatio(choice2));
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.C:
                        Console.Clear(); 
                        Console.WriteLine("\nSuperSimpleStocks Application - by Ion Ruiz Iragui\n\n");
                        ShowAll();
                        Console.WriteLine("[C]. Record a trade");
                        Console.Write("Insert the Quantity: ");
                        String quantity = Console.ReadLine();
                        Console.Write("Insert the Type (B)uy/(S)ell): ");
                        String type = Console.ReadLine();
                        Console.Write("Insert the Price (decimals with comma): ");
                        String price = Console.ReadLine();
                        Trade trade = new Trade(quantity,type,price);
                        BLL.insertTrade(trade);
                        Console.WriteLine("\n\nInsertion completed!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D:
                        Console.WriteLine("[D]. Calculate Stock Price based on trades recorded in the last X");
                        Console.Write("Mins Lapse: ");
                        String timeInMins = Console.ReadLine();
                        Double stockPrice = BLL.LastMinsTrades(int.Parse(timeInMins));
                        Console.WriteLine("\nStock Price of the last " + timeInMins + " minutes: " + stockPrice);
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.E:
                        Console.WriteLine("[E]. Calculate the GBCE All Share Index");
                        Double GBCE = BLL.CalculateGBCE();
                        Console.WriteLine("\nGBCE All Share Index: " + GBCE);
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("Chao");

                        break;
                }
            } while (op.Key != ConsoleKey.Escape);
        }


        public static void ShowAll() {
            List<Stock> listToDisplay = BLL.AllStocks();
            DisplayData(listToDisplay);
        }

        public static void DisplayData(List<Stock> listToDisplay)
        { 
        
            Console.WriteLine("********************* DATASOURCE *****************************");
            foreach (Stock k in listToDisplay)
            {
                Console.WriteLine("\t" + k.symbol + "\t" +
                    k.type + "\t\t"+
                    k.lastDividend + "\t"+
                    k.fixedDividend + "\t" +
                    k.parValue + "\t"
                    );
            }
            Console.WriteLine("**************************************************************\n\n");
        
        }
    }
}
