using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public class BLL
    {

        int tickerPrice=100;
        private static String filePath = "C:\\Data\\tradeRecord.txt";

        public static List<Stock> AllStocks() {
            return Stock.getStocks();
        }


        public static Double calculateDividendYield(String stockSymbol){

            Double returnValue=0;
            Stock stock = Stock.findStockbySymbol(stockSymbol);
            try
            {
                if (stock.type.Equals("Preferd"))
                {
                    returnValue = stock.lastDividend / tickerPrice;
                }
                else if (stock.type.Equals("Common"))
                {
                    returnValue = stock.fixedDividend * stock.parValue / tickerPrice;
                }
                else
                {
                    Console.WriteLine("WARNING: Wrong Stock type!!");
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("ERROR: DivideByZeroException: Have a look on the stock.parValue of the Stock= " + stock.symbol);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Ooops! Something went wrong");
                Console.WriteLine("ERROR MESSAGE: " + ex.Message);
            }
            return returnValue;
        }

        public static Double PERatio(String stockSymbol)
        {
            Double returnValue = 0;
            Stock stock = Stock.findStockbySymbol(stockSymbol);
            try {
                returnValue = tickerPrice / stock.lastDividend;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Ooops! Something went wrong");
                Console.WriteLine("ERROR MESSAGE: " + ex.Message);
            }
            return returnValue;
        }



        public static void insertTrade(Trade trade)
        {
            int nextLine = System.IO.File.ReadLines(filePath).Count() + 1;
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath,true);
            
            file.WriteLine(nextLine + "\t" + 
                DateTime.Now + "\t" + 
                trade.quantityShares  + "\t" +  
                trade.type  + "\t" + 
                trade.price);
            file.Close();
        }

        


        public static Double LastMinsTrades(int timeInMins)
        {
            String[] currentLine;
            String text;
            Double returnValue=0;
            int tradeCounter = 0;
            using (var reader = System.IO.File.OpenText(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    //DEBUG text = reader.ReadLine();
                    currentLine = reader.ReadLine().Split('\t');
                    if (DateTime.Parse(currentLine[1]) > DateTime.Now.AddMinutes(-timeInMins))
                    { 
                        returnValue += Double.Parse(currentLine[4])*int.Parse(currentLine[2]);
                        tradeCounter += int.Parse(currentLine[2]);
                    }
                }
            }
            return (returnValue / tradeCounter);
        }

        public static Double CalculateGBCE()
        {
            Double returnValue = 1;
            Double priceMulti = 1;

            String[] currentLine;
            int count = 0;
            using (var reader = System.IO.File.OpenText(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    currentLine = reader.ReadLine().Split('\t');
                    priceMulti *= Double.Parse(currentLine[4]) * int.Parse(currentLine[2]);
                    count++;                 
                }
            }
            returnValue = (Math.Pow(priceMulti, (Double)1 / count));
            return Math.Round(returnValue,2);
        }
    }
}
