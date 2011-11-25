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
      register_a_dependency<IBuildRequestMatchers>(() => new RequestMatchBuilder());
      register_a_dependency<MatchBuilderFactory>(() => (MatchBuilderFactory) Container.fetch.an<IBuildRequestMatchers>);
      register_a_dependency<IFindPathsToViews>(Stub.with<StubPathRegistry>);
      register_a_dependency<ICreateAResponse>(()=>new PageFactory(Container.fetch.an<IFindPathsToViews>(), BuildManager.CreateInstanceFromVirtualPath));
      register_a_dependency<IDisplayReportModels>(() => new WebResponseEngine(Container.fetch.an<ICreateAResponse>(), () => HttpContext.Current));
      register_a_dependency<IFindCommands>(() => new CommandRegistry(Stub.with<StubSetOfCommands>(), Stub.with<StubMissingCommand>()));
      register_a_dependency<ICreateRequests>(Stub.with<StubRequestFactory>);
      register_a_dependency<IProcessRequests>(() => new FrontController(Container.fetch.an<IFindCommands>()));
    }

    static void register_a_dependency<RegisteredType>(Func<object> factory_method)
    {
      dependencies.Add(typeof(RegisteredType), new SimpleFactory(factory_method));
    }
  }
}