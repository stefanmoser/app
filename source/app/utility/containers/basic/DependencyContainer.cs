using System;
using System.Collections.Generic;

namespace app.utility.containers.basic
{
  public class DependencyContainer : IFetchDependencies
  {
    IDictionary<Type,ICreateADependency> dependencies;

    public DependencyContainer(IDictionary<Type,ICreateADependency> dependencies)
    {
      this.dependencies = dependencies;
    }

    public Dependency an<Dependency>()
    {
      return (Dependency)an(typeof(Dependency));
    }

    public object an(Type type)
    {
      try
      {
        return dependencies[type].create();
      }
      catch (Exception e)
      {
        throw new DependencyCreationException(type, e);
      }
    }
  }
}
