using System;

namespace app.utility.containers.basic
{
  public interface IFindFactoriesForDependencies
  {
    ICreateADependency get_the_factory_that_can_create(Type dependency_type);
  }
}