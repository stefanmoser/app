using System;
using System.Collections.Generic;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public class ContainerRegistrationServices : IProvideContainerRegistrationServices
  {
    ICreateDependencyFactories factory_provider;
    IDictionary<Type, ICreateADependency> factories;

    public ContainerRegistrationServices(ICreateDependencyFactories factory_provider, IDictionary<Type, ICreateADependency> factories)
    {
      this.factory_provider = factory_provider;
      this.factories = factories;
    }

    public ICreateADependency get_the_factory_that_can_create(Type dependency_type)
    {
      ensure_there_is_a_factory_registered_for(dependency_type);
      return factories[dependency_type];
    }
  
    void ensure_there_is_a_factory_registered_for(Type type){
      if (factories.ContainsKey(type)) return;

      throw new DependencyFactoryNotRegisteredException(type);
    }

    public void register<Implementation>()
    {
      register<Implementation,Implementation>();
    }

    public void register<Contract, Implementation>() where Implementation : Contract
    {
      add_factory<Contract>(factory_provider.create_factory_to_automatically_create(typeof(Implementation)));
    }

    void add_factory<Contract>(ICreateADependency factory)
    {
      factories.Add(typeof(Contract),factory);
    }

    public void register_instance<RegisteredType>(RegisteredType item)
    {
      add_factory<RegisteredType>(factory_provider.create_factory_for_instance(item));  
    }
  }
}
