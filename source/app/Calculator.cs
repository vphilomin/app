using System;
using System.Data;
using System.Security.Principal;

namespace app
{
    public class Calculator
    {
        IDbConnection connection;
        IPrincipal principal;

        public Calculator(IDbConnection connection, IPrincipal principal)
        {
            this.connection = connection;
            this.principal = principal;
        }

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int i, int i1)
        {
            if (i < 0 || i1 < 0)
                throw new ArgumentException("Negative numbers not allowed");

            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            return i + i1;
        }

        public void shut_off()
        {
            if (principal.IsInRole("blah"))
                return;
        }
    }
}