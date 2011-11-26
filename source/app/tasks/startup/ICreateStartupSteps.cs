using System;
using System.Collections.Generic;
using app.utility.containers;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public interface ICreateStartupSteps
  {
    IRunAStartupStep create_step_from(Type step);
  }

  class CreateStartupSteps : ICreateStartupSteps
  {

    public IRunAStartupStep create_step_from(Type step)
    {
      ICreateDependencyFactories factory = new FactoriesProvider(new LazyContainer());
      var container_registration_services = new ContainerRegistrationServices(factory, new Dictionary<Type, ICreateADependency>());

      return (IRunAStartupStep)Activator.CreateInstance(step,
                                      container_registration_services);
    }

  }

  public class LazyContainer : IFetchDependencies
  {
    public Dependency an<Dependency>()
    {
      return Container.fetch.an<Dependency>();
    }

    public object an(Type type)
    {
      return Container.fetch.an(type);
    }
  }

  public class FactoriesProvider:ICreateDependencyFactories
  {
    IFetchDependencies container;

    public FactoriesProvider(IFetchDependencies container)
    {
      this.container = container;
    }

    public ICreateADependency create_factory_to_automatically_create(Type type)
    {
      return new AutomaticDependencyFactory(container, new GreedyConstructorSelectionStrategy(), type);
    }

    public ICreateADependency create_factory_for_instance(object instance)
    {
      return new SimpleFactory(() => instance);
    }
  }
}