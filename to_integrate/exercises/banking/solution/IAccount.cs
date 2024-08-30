using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public interface IReadOnlyAccount
    {
        double GetBalance();
    }
    public interface IAccount: IReadOnlyAccount
    {
        void Deposit(double val);
        void Withdraw(double val);

    }
}
