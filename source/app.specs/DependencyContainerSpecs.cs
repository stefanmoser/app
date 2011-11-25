using Machine.Specifications;
using app.utility.containers;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(DependencyContainer))]
  public class DependencyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      DependencyContainer>
    {
    }

    public class when_fetching_a_dependency : concern
    {
      Establish c = () =>
      {
        dependencies = depends.on<IMapDependencies>();
      };
      Because b = () =>
        sut.an<ThatsWhatSheSaid>();

      It should_lookup_the_dependency_in_the_dependency_registry = () =>
        dependencies.received(x => x.map<ThatsWhatSheSaid>());

      static IMapDependencies dependencies;


    }
  }

  class ThatsWhatSheSaid
  {
  }
}