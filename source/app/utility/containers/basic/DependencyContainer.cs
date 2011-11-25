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
      try
      {
        return (Dependency) dependencies[typeof(Dependency)].create();
      }
      catch (Exception e)
      {
        throw new DependencyCreationException(typeof(Dependency), e);
      }
    }
  }
}