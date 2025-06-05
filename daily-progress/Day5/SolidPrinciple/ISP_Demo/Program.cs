using ISP_Demo.Interfaces;
using ISP_Demo.Models;
using ISP_Demo;
Console.OutputEncoding = System.Text.Encoding.UTF8;


Console.WriteLine("Interface Segregation Principle Demo");

IBasicAccount savings = new SavingsAccount();
savings.Deposit(19000);
savings.Withdraw(3000);
savings.CheckBalance(1);

Console.WriteLine();

IInvestmentAccount investment = new InvestmentAccount();
investment.Deposit(23000);
investment.Buyshares(3);
investment.SellShares(2);
investment.Withdraw(1000);

Console.ReadLine();
