using Lab1.banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.banking
{
    public interface IReadOnlyAccount
    {
        double GetBalance();
    }
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

    abstract class DecoratorAccount : IAccount
    {
        public DecoratorAccount(IAccount account)
        {
            Account = account;
        }
        public IAccount Account { get; set; }
        public abstract void Deposit(double val);
        public abstract double GetBalance();
        public abstract void Withdraw(double val);
    }

    class CommisionAccount : DecoratorAccount
    {
        public double Commision { get; set; }
        public IAccount Account { get; set; }
        public CommisionAccount(IAccount account, double commision) : base(account)
        {
            Commision = commision;
            Account = account;


        }
        public override void Withdraw(double val)
        {
            Account.Withdraw(val + Commision);
        }
        public override void Deposit(double val)
        {
            Account.Deposit(val - Commision);
        }

        public override double GetBalance()
        {
            Account.Withdraw(Commision);
            return Account.GetBalance();
        }
    }

    class TraceAccount : DecoratorAccount
    {
        public IAccount Account { get; set; }
        public TraceAccount(IAccount account) : base(account)
        {
            Account = account;
        }
        
        public override void Withdraw(double val)
        {
            Account.Withdraw(val);
            Console.WriteLine($"[TraceDecorator]: Withdraw  {val}");
        }

        public override double GetBalance()
        {
            var val = Account.GetBalance();
            Console.WriteLine($"[TraceDecorator]: GetBalance {val}");
            return val;
        }

        public override void Deposit(double val)
        {
            Account.Deposit(val);
            Console.WriteLine($"[TraceDecorator]: Deposit  {val}");

        }
    }
}
