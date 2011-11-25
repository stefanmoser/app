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
		try
		{
			return (Dependency)dependencies.get_the_factory_that_can_create(typeof(Dependency)).create();
		}
		catch (Exception e)
		{
			throw new DependencyCreationException("Cannot create type", typeof(Dependency), e);
		}
	}
  }
}