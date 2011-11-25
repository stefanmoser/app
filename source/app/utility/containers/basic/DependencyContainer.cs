using System;

namespace app.utility.containers.basic
{
  public class DependencyContainer : IFetchDependencies
  {
    IFindFactoriesForDependencies dependencies;

    public DependencyContainer(IFindFactoriesForDependencies dependencies)
    {
      this.dependencies = dependencies;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency) an(typeof(Dependency));
    }

    public object an(Type type)
    {
      try
      {
        return dependencies.get_the_factory_that_can_create(type).create();
      }
      catch (Exception e)
      {
        throw new DependencyCreationException(type, e);
      }
    }
  }
}