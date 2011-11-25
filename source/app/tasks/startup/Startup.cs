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
      register<IBuildRequestMatchers>(() => new RequestMatchBuilder());
      register<IFindPathsToViews>(Stub.with<StubPathRegistry>);
      register<ICreateAResponse>(()=>new PageFactory(Container.fetch.an<IFindPathsToViews>(), BuildManager.CreateInstanceFromVirtualPath));
      register<IDisplayReportModels>(() => new WebResponseEngine(Container.fetch.an<ICreateAResponse>(), () => HttpContext.Current));
      register<IFindCommands>(() => new CommandRegistry(Stub.with<StubSetOfCommands>(), Stub.with<StubMissingCommand>()));
      register<ICreateRequests>(Stub.with<StubRequestFactory>);
      register<IProcessRequests>(() => new FrontController(Container.fetch.an<IFindCommands>()));
    }

    static void register<RegisteredType>(Func<object> factory_method)
    {
      dependencies.Add(typeof(RegisteredType), new SimpleFactory(factory_method));
    }
  }
}