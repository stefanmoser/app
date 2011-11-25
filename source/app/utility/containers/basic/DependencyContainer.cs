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
      return (Dependency)dependencies.get_the_factory_that_can_create(typeof(Dependency)).create();
    }
  }
}