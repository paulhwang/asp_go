using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Models
{
    public class AccountDataOperationClass : DataOperationInterface<AccountClass>
    {
        public IEnumerable<AccountClass> Get()
        {
            System.Data.IDbConnection connection = null;
            System.Data.IDbCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM Accounts");
            cmd.Connection = connection;

            throw new NotImplementedException();
        }

        public void Create(AccountClass item_val)
        {

        }

        public void Update(AccountClass item_val)
        {

        }

        public void Delete(AccountClass item_val)
        {

        }
    }
}
