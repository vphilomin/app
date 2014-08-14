using System;
using app.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(StepFactory))]
  public class StepFactorySpecs
  {
    public abstract class concern : Observes<ICreateAStartupStep,
      StepFactory>
    {
    }

    public class when_creating_a_step : concern
    {
      public class and_it_follows_the_convention_for_a_startup_step
      {
        Establish c = () =>
        {
          startup_services = fake.an<IProvideStartupServices>();
          depends.on<Func<IProvideStartupServices>>(() => startup_services);
        };

        Because b = () =>
          result = sut.create(typeof(AStep));

        It returns_the_step_with_the_startup_services_provided = () =>
        {
          var step = result.ShouldBeAn<AStep>();
          step.startup_services.ShouldEqual(startup_services);
        };

        static IRunAStartupStep result;
        static IProvideStartupServices startup_services;
      }
    }

    public class AStep :IRunAStartupStep
    {
      public IProvideStartupServices startup_services;

      public AStep(IProvideStartupServices startup_services)
      {
        this.startup_services = startup_services;
      }

      public void run()
      {
        throw new NotImplementedException();
      }
    }
  }
}