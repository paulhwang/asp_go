using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Models
{
    public class AccountDataOperationClass : DataOperationInterface<AccountClass>
    {
        private string connectionString = @"Server=(localdb)\v11.0;
                                            Integrated Security=true;
                                            AttachDbFileName=" + Environment.CurrentDirectory + @"\Go.mdf;";

        public IEnumerable<AccountClass> Get()
        {
            System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(this.connectionString);
            System.Data.IDbCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM Accounts");
            cmd.Connection = connection;
            //connection.Open();

            return null;

        }

        public void Create(AccountClass item_val)
        {
            throw new NotImplementedException();

        }

        public void Update(AccountClass item_val)
        {

        }

        public void Delete(AccountClass item_val)
        {

        }
    }
}
