using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Models
{
    public class ModelRootClass
    {
        private AccountModellClass accountModelOject { get; }
        private IEnumerable<AccountClass> accountsData { get; }

        public ModelRootClass()
        {
            this.accountModelOject = new Models.AccountModellClass();
            this.accountsData = this.accountModelOject.AccountOperation.Get();

            /*
            foreach (AccountClass account in this.accountsData)
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
                */
        }
    }
}
