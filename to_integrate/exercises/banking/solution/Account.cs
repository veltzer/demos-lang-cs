using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    
    public class AccountBase : IAccount
    {
        private double _balance;
        public virtual void Deposit(double val)
        {
            _balance += val;
        }

        public virtual double GetBalance()
        {
            Console.WriteLine(this.GetType());
            return _balance;
        }

        public virtual void Withdraw(double val)
        {
            _balance -= val;
            Console.WriteLine("Base wothdraw");
        }
    }

    class CheckingAccount : AccountBase
    {
        private double _overDraft;
        public override void Withdraw(double val)
        {
            base.Withdraw(val);
        }
    }
    class SavingAccount : AccountBase
    {
        private static int _intRate;

        public static void SetInterest(int val)
        {
            _intRate = val;
        }

    }

    
}
