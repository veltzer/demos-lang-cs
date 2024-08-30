using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public enum AccountType { Saving,Checking}
   
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
                    return new SavingAccountProxy();
                case AccountType.Checking:
                    return new TraceAccount(new CommisionAccount(new CheckingAccount(), 10));
                  
            }
            throw new NotSupportedException();
        }

        
    }
}
