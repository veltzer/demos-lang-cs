using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
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
        private IAccount _account;
        public CommisionAccount(IAccount account, double commision) : base(account)
        {
            Commision = commision;
            _account = account;
        }
        public override void Withdraw(double val)
        {
            _account.Withdraw(val + Commision);
        }
        public override void Deposit(double val)
        {
            _account.Deposit(val - Commision);
        }

        public override double GetBalance()
        {
            _account.Withdraw(Commision);
            return _account.GetBalance();
        }
    }

    class TraceAccount : DecoratorAccount
    {
        private IAccount _account;
        public TraceAccount(IAccount account) : base(account)
        {
            _account = account;
        }
        
        public override void Withdraw(double val)
        {
            _account.Withdraw(val);
            Console.WriteLine($"Decorator Withdraw  {val}");
        }

        public override double GetBalance()
        {
            var val = _account.GetBalance();
            Console.WriteLine($"Decorator GetBalance {val}");
            return val;
        }

        public override void Deposit(double val)
        {
            _account.Deposit(val);
            Console.WriteLine($"Decorator Deposit  {val}");

        }
    }
}
