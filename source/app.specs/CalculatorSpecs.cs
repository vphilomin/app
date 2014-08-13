using System;
using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class context : Observes<Calculator>
    {
    }

    public class when_adding
    {
      public class two_positive_numbers : context
      {
        Establish c = () =>
        {
          connection = depends.on<IDbConnection>();   
        };

        Because b = () =>
          result = sut.add(2, 3);

        It opens_a_connection_to_the_database = () =>
          connection.received(x => x.Open());
          
        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;
        static IDbConnection connection;
      }

      public class a_negative_with_a_positive : context
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It does_not_work = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();
      }
    }
  }
}