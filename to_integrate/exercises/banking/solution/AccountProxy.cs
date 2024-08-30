using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class SavingAccountProxy : IAccount
    {
        private IAccount _account;
        public void Deposit(double val)
        {
            Load();
            _account.Deposit(val);  
        }

        public double GetBalance()
        {
            Load();
            return _account.GetBalance();
        }

        public void Withdraw(double val)
        {
            Load();
            _account.Withdraw(val);
        }
        private void Load()
        {
            if(_account== null) {
                _account = new SavingAccount();
                Console.WriteLine("Proxy loading object");
            }
        }
    }
}
