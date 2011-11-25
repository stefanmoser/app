using System;
using System.Collections.Generic;
using app.utility.containers;
using app.utility.containers.basic;
using app.web.core;

namespace app.tasks.startup
{
  public class Startup
  {
    static IDictionary<Type, ICreateADependency> dependencies;

    public static void run()
    {
      dependencies =  new Dictionary<Type, ICreateADependency>();
      IFetchDependencies container = new DependencyContainer(dependencies);
      ContainerFacadeResolution facade_resolution = () => container;
      Container.facade_resolution = facade_resolution;

      wire_everything_up();
    }

    static void wire_everything_up()
    {
      dependencies.Add(typeof(IProcessRequests),new SimpleFactory(() => new FrontController()));
    }
  }
}