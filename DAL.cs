using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public class Stock
    {
        public string symbol;
        public string type;
        public int lastDividend;
        public Double fixedDividend;
        public int parValue;

        static String[,] stockData = {
                                {"TEA","Common","0",null,"100"},
                                {"POP","Common","8",null,"100"},
                                {"ALE", "Common", "23", null, "60"},
                                {"GIN", "Preferd", "8", "0.02", "100"},
                                {"JOE", "Common", "13",null, "250"}
                              };

        public Stock()
        { }

        public static List<Stock> getStocks(){
            List<Stock> listSotck = new List<Stock>();

            for (int i = 0; i <= 4; i++)
            {
                Stock newStock = new Stock();
                newStock.symbol = stockData[i, 0];
                newStock.type = stockData[i, 1];
                newStock.lastDividend = int.Parse(stockData[i, 2]);
                if (stockData[i, 3] == null)
                    newStock.fixedDividend = 0;
                else
                    newStock.fixedDividend = Double.Parse(stockData[i, 3]);
                newStock.parValue = int.Parse(stockData[i, 4]);
                listSotck.Add(newStock);
            }
            return listSotck;
             
        }

        public static Stock findStockbySymbol(String symbol1)
        {
            Stock listSotck = getStocks().Find(Stock=>Stock.symbol == symbol1);
            return listSotck;

        }


    }

    public class Trade {


        public DateTime timestap;
        public int quantityShares;
        public String type;
        public Double price;


        public Trade()
        { 
        }


        public Trade(String quantity,String type, String price)
        {
            this.timestap = DateTime.Today;
            this.quantityShares = int.Parse(quantity);
            this.type = type;
            this.price = Double.Parse(price);
        }
    }

}
