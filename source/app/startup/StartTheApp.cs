using System;
using app.basic_container;
using app.container;
using app.core;
using app.web.aspnet.stubs;

namespace app.startup
{
  public class StartTheApp
  {
    public class LazyContainer : IFetchDependencies
    {
      public Dependency an<Dependency>()
      {
        return Dependencies.fetch.an<Dependency>();
      }

      public object an(Type type)
      {
        return Dependencies.fetch.an(type);
      }
    }

    public static ICreateAStartupChain chain_builder = type =>
    {
      var factory_builder = new BuildDependencyFactories(new LazyContainer());
      var factory = new StepFactory(() => new StartupServices(factory_builder));
      IRun step = factory.create(type);

      return new StartupPipelineBuilder(step, factory, WebStubs.combine_actions);
    };

    public static IBuildAStartupChain by<StartupStep>() where StartupStep : IRunAStartupStep
    {
      return chain_builder(typeof(StartupStep));
    }
  }
}