using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class BankAccount
    {
        private double balance;
        public string Name { get; private set; }
        public double Balance
        {
            get { return balance; }
            private set
            {
                if (value < 0.0)
                {
                    Console.WriteLine("No negative quantities allowed...");
                    this.balance = 0.0;
                }
                else
                {
                    this.balance = value;
                }
            }
        }

        private BankAccount() { }

        public BankAccount(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
            this.ShowInfo();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Account name: {this.Name}");
            Console.WriteLine($"Balance: ${this.Balance:0.00}\n");
        }

        public void AddMoney(double qty)
        {
            this.Balance += qty;
            this.ShowInfo();
        }

        public void MakeWithdraw(double qty)
        {
            if (qty > this.Balance)
            {
                Console.WriteLine("Not enough money...");
            }
            else
            {
                this.Balance -= qty;
            }
            this.ShowInfo();
        }
    }
}
