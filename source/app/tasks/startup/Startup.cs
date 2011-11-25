using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility.containers;
using app.utility.containers.basic;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class Startup
  {
    static IDictionary<Type, ICreateADependency> dependencies;

    public static void run()
    {
      dependencies = new Dictionary<Type, ICreateADependency>();
      IFetchDependencies container = new DependencyContainer(dependencies);
      ContainerFacadeResolution facade_resolution = () => container;
      Container.facade_resolution = facade_resolution;

      wire_everything_up();
    }

    static void wire_everything_up()
    {
      dependencies.Add(typeof(IBuildRequestMatchers), new SimpleFactory(() => new RequestMatchBuilder()));

      dependencies.Add(typeof(MatchBuilderFactory),
                       new SimpleFactory(() => (MatchBuilderFactory) Container.fetch.an<IBuildRequestMatchers>));

      dependencies.Add(typeof(IFindPathsToViews), new SimpleFactory(Stub.with<StubPathRegistry>));

      dependencies.Add(typeof(ICreateAResponse),
                       new SimpleFactory(
                         () =>
                           new PageFactory(Container.fetch.an<IFindPathsToViews>(),
                                           BuildManager.CreateInstanceFromVirtualPath)));

      dependencies.Add(typeof(IDisplayReportModels),
                       new SimpleFactory(
                         () => new WebResponseEngine(Container.fetch.an<ICreateAResponse>(), () => HttpContext.Current)));

      dependencies.Add(typeof(IFindCommands),
                       new SimpleFactory(
                         () => new CommandRegistry(Stub.with<StubSetOfCommands>(), Stub.with<StubMissingCommand>())));

      dependencies.Add(typeof(ICreateRequests), new SimpleFactory(Stub.with<StubRequestFactory>));

      var fc = new FrontController(Container.fetch.an<IFindCommands>());
      dependencies.Add(typeof(IProcessRequests), new SimpleFactory(() => fc));
    }
  }
}