using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class BankAccount
    {
        // Money
        private double balance;
        // Account owner
        public string Name { get; private set; }
        public double Balance
        {
            // Normal 'get'
            get { return balance; }
            private set
            {
                // Only positive values
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

        // No 'empty' bank account with no owner possible
        private BankAccount() { }

        // 'Normal constructor, owner and balance
        public BankAccount(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
            this.ShowInfo();
        }

        // Show information
        public void ShowInfo()
        {
            Console.WriteLine($"Account name: {this.Name}");
            Console.WriteLine($"Balance: ${this.Balance:0.00}\n");
        }

        // Add money, no negative values
        public void AddMoney(double qty)
        {
            this.Balance += qty;
            this.ShowInfo();
        }

        // Validate withdrawals
        public void MakeWithdraw(double qty)
        {
            // Greater than current balance, fail...
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
