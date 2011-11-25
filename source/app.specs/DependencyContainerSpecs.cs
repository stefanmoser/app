using System;
using System.Collections.Generic;
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
      public class and_everything_is_all_good
      {
        Establish c = () =>
        {
          the_item = new ThatsWhatSheSaid();
          factory = fake.an<ICreateADependency>();
          dependencies = new Dictionary<Type, ICreateADependency>();
          dependencies.Add(typeof(ThatsWhatSheSaid),factory);
          depends.on(dependencies);

          factory.setup(x => x.create()).Return(the_item);
        };

        Because b = () =>
          result = sut.an<ThatsWhatSheSaid>();

        It should_find_the_factory_that_can_create_the_dependency = () =>
        {
        };

        It should_return_the_item_created_by_the_factory = () =>
          result.ShouldEqual(the_item);




      }

      public class and_the_factory_for_the_dependency_throws_an_exception_when_creating_the_item
      {
        Establish c = () =>
        {
          the_item = new ThatsWhatSheSaid();
          factory = fake.an<ICreateADependency>();
          the_inner_exception = new Exception();
          dependencies = new Dictionary<Type, ICreateADependency>();
          dependencies.Add(typeof(ThatsWhatSheSaid),factory);
          depends.on(dependencies);

          factory.setup(x => x.create()).Throw(the_inner_exception);
        };

        Because b = () =>
          spec.catch_exception(() => sut.an<ThatsWhatSheSaid>());


        It should_throw_a_dependency_creation_exception_with_the_necessary_information = () =>
        {
          var item = spec.exception_thrown.ShouldBeAn<DependencyCreationException>();
          item.type_that_could_not_be_created.ShouldEqual(typeof(ThatsWhatSheSaid));
          item.InnerException.ShouldEqual(the_inner_exception);
        };

        static Exception the_inner_exception;

      }
      static IDictionary<Type, ICreateADependency> dependencies;
      static ICreateADependency factory;
      static ThatsWhatSheSaid result;
      static ThatsWhatSheSaid the_item;
    }
  }

  class ThatsWhatSheSaid
  {
  }
}