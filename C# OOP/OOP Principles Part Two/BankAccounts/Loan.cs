﻿namespace BankAccounts
{
    using System;

    public class Loan : Account, IWithDrawable
    {
        public Loan(Customer customer, decimal balance, decimal interestRate, CurrencyType currency)
            : base(customer, balance, interestRate, currency)
        {
        }
        
        public override decimal InterestAmountForPeriod(int months)
        {
            if (this.customer.GetType().Name == "Individual" && months < 4)
            {
                this.InterestRate = 0;
            }
            else if (this.customer.GetType().Name == "Company" && months < 3)
            {
                this.InterestRate = 0;
            }

            return months * this.InterestRate;
        }

        public decimal WithDraw(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Cannot withdraw negative money");
            }
            else if (money > this.Balance)
            {
                throw new ArgumentException("Cannot withdraw more than the money you already have");
            }
            else
            {
                this.Balance -= money;
                return money;
            }
        }
    }
}
