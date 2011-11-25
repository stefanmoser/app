using System;
using System.Collections.Generic;
using app.utility.containers;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public class ConfiguringTheContainer : IRunAStartupStep
  {
    IProvideContainerRegistrationServices registration;

    public ConfiguringTheContainer(IProvideContainerRegistrationServices registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      var dependencies = new Dictionary<Type, ICreateADependency>();
      var container = new DependencyContainer(dependencies);
      ContainerFacadeResolution facade_resolution = () => container;
      Container.facade_resolution = facade_resolution;
      registration.register_instance(container);
    }
  }
}