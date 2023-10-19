using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest {  get; set; }
        public string BrokerName { get; set; }
        public List<Stock> Portfolio { get; set; }
        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest > stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
           if (!Portfolio.Any(x=> x.CompanyName == companyName))
           {
               return $"{companyName} does not exist.";
           }
        
           if (Portfolio.Any(x => x.PricePerShare > sellPrice))
           {
               return $"Cannot sell {companyName}.";
           }
            
            Portfolio.Remove(Portfolio.First(x => x.CompanyName == companyName));
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            Stock stock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            return stock;
        }
        public Stock FindBiggestCompany()
        {
            decimal max = this.Portfolio.Max(x => x.MarketCapitalization);
            Stock stock = this.Portfolio.FirstOrDefault(x => x.MarketCapitalization == max);
            return stock;
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var investor in Portfolio)
            {
                sb.AppendLine(investor.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
