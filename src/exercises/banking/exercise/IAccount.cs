using lab1.banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.banking
{
    public interface IAccount: IReadOnlyAccount
    {
        void Deposit(double val);
        void Withdraw(double val);

    }
}
