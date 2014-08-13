using System;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class context : Observes<Calculator>
    {
      
    }

    public class when_adding
    {
      public class two_positive_numbers: context
      {
        Because b = () =>
          result = sut.add(2, 3);

        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;
      }

      public class a_negative_with_a_positive: context
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It throws_an_argument_error = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();

      }

    }
  }
}