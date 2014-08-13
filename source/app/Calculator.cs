using System;
using System.Data;

namespace app
{
  public class Calculator
  {
      private readonly IDbConnection _connection;

      public Calculator(IDbConnection connection)
      {
          _connection = connection;
      }

      public int add(int i, int i1)
    {
        if (i < 0 || i1 < 0)
            throw new ArgumentException("Negative numbers not allowed");

        _connection.Open();
        return i + i1;
    }
  }
}