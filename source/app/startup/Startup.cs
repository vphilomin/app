using System;
using System.Collections.Generic;
using System.Web;
using app.basic_container;
using app.container;
using app.web.aspnet;
using app.web.aspnet.stubs;
using app.web.core;

namespace app.startup
{
  public class Startup
  {
    static IList<ICreateOneDependency> factories;

    public static void run()
    {
      factories = new List<ICreateOneDependency>();
      var dependency_factories = new DependencyFactories(factories, WebStubs.missing_dependency_factory);
      var container = new Container(dependency_factories, WebStubs.dependency_creation_error);
      Dependencies.provide_access_to_the_container = () => container;

      register<IProcessWebRequests, FrontController>(() => new FrontController(container.an<IFindCommandsThatCanProcessRequests>()));
      register<IFindCommandsThatCanProcessRequests, CommandRegistry>(() => new CommandRegistry(container.an<IEnumerable<IProcessOneRequest>>(),
        WebStubs.missing_command_factory));

      register<IDisplayInformation, WebFormDisplayEngine>(() => new WebFormDisplayEngine(
        container.an<IGetTheCurrentHttpContext>(),
        container.an<ICreateViewsThatCanDisplayAReport>()));

      register<IGetTheCurrentHttpContext>(() => HttpContext.Current);

      register<ICreateViewsThatCanDisplayAReport, WebFormFactory>(() => new WebFormFactory(
        container.an<IFindPathsToViews>(),
        container.an<ICreatePageInstances>()));

      register(WebStubs.create_page);
      register<IFindPathsToViews>(new StubPathRegistry());
      register<IEnumerable<IProcessOneRequest>>(new StubSetOfCommands());
      register(WebStubs.request_factory);
    }

    public static void register<Contract, Implementation>(Func<Implementation> factory) where 
      Implementation : Contract
    {
      factories.Add(new CreateOneDependency(
        new SimpleFactory(() => factory()), WebStubs.is_a<Contract>())); 
    }

    public static void register<Contract>(Contract instance)
    {
      factories.Add(new CreateOneDependency(
        new SimpleFactory(() => instance), WebStubs.is_a<Contract>())); 
    }
  }
}