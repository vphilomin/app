using app.startup;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(StartTheApp))]
  public class StartTheAppSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_observation_name : concern
    {
    }
  }
}