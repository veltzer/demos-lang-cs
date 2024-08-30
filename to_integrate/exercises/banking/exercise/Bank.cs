using Lab1.banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.banking
{
    public enum AccountType { Saving,Checking}
    public enum DecoratorType { Commission, Trace}
    public class Bank
    {
        private static Bank _bank = new Bank();
        private Bank() { }
        public static Bank Instance{ get { 
                return _bank;
            }
        }
        public IAccount CreateAccount(AccountType type)
        {
            switch (type) {     
                case AccountType.Saving:
                    return new SavingAccount();
                case AccountType.Checking:
                   return new CheckingAccount();
            }
            throw new NotSupportedException();
        }

        public IAccount DecorateAccount(DecoratorType dType, AccountType type)
        {
            switch (dType)
            {
                case DecoratorType.Commission:
                    double val = 10;
                    return new CommisionAccount(CreateAccount(type), val);
                case DecoratorType.Trace:
                    return new TraceAccount(CreateAccount(type));
            }
            throw new NotSupportedException();
        }
    }
}
