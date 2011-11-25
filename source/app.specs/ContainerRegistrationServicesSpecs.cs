using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ContainerRegistrationServices))]
  public class ContainerRegistrationServicesSpecs
  {
    public abstract class concern_for_lookup : Observes<IFindFactoriesForDependencies,
                                                 ContainerRegistrationServices>
    {
    }

    public abstract class concern_for_registration : Observes<IProvideContainerRegistrationServices,
                                                       ContainerRegistrationServices>
    {
    }

    public class when_getting_a_factory_for_a_dependency : concern_for_lookup
    {
      public class and_it_has_the_factory
      {
        Establish c = () =>
        {
          the_factory = fake.an<ICreateADependency>();
          dependencies = new Dictionary<Type, ICreateADependency>();
          depends.on(dependencies);
          dependencies.Add(typeof(OurType), the_factory);
        };

        Because b = () =>
          result = sut.get_the_factory_that_can_create(typeof(OurType));

        It should_return_the_factory_that_can_create_the_dependency = () =>
          result.ShouldEqual(the_factory);

        static ICreateADependency the_factory;
        static ICreateADependency result;
        static IDictionary<Type, ICreateADependency> dependencies;
      }

      public class and_it_does_not_have_the_factory
      {
        Establish c = () =>
        {
          dependencies = new Dictionary<Type, ICreateADependency>();
          the_factory = fake.an<ICreateADependency>();
          depends.on(dependencies);
        };

        Because b = () =>
          spec.catch_exception(() => sut.get_the_factory_that_can_create(typeof(OurType)));

        It should_return_the_factory_that_can_create_the_dependency = () =>
        {
          var item = spec.exception_thrown.ShouldBeAn<DependencyFactoryNotRegisteredException>();

          item.type_that_has_no_factory.ShouldEqual(typeof(OurType));
        };

        static ICreateADependency the_factory;
        static ICreateADependency result;
        static IDictionary<Type, ICreateADependency> dependencies;
      }
    }

    public class when_registering_an_item : concern_for_registration
    {
      public class by_contract_and_implementation
      {
        Establish c = () =>
        {
          factory_provider = depends.on<ICreateDependencyFactories>();
          items = new Dictionary<Type, ICreateADependency>();
          depends.on(items);
          the_factory = fake.an<ICreateADependency>();

          factory_provider.setup(x => x.create_factory_to_automatically_create(typeof(OurType))).Return(the_factory);
        };

        Because b = () =>
          sut.register<IOurType, OurType>();

        It should_add_the_factory_that_can_create_the_type_into_the_dictionary = () =>
          items[typeof(IOurType)].ShouldEqual(the_factory);

        static IDictionary<Type, ICreateADependency> items;
        static ICreateADependency the_factory;
        static ICreateDependencyFactories factory_provider;
      }

      public class by_instance
      {
        Establish c = () =>
        {
          factory_provider = depends.on<ICreateDependencyFactories>();
          items = new Dictionary<Type, ICreateADependency>();
          our_type = new OurType();
          depends.on(items);
          the_factory = fake.an<ICreateADependency>();

          factory_provider.setup(x => x.create_factory_for_instance(our_type)).Return(the_factory);
        };

        Because b = () =>
          sut.register_instance<IOurType>(our_type);

        It should_add_the_factory_that_can_create_the_type_into_the_dictionary = () =>
          items[typeof(IOurType)].ShouldEqual(the_factory);

        static IDictionary<Type, ICreateADependency> items;
        static ICreateADependency the_factory;
        static ICreateDependencyFactories factory_provider;
        static OurType our_type;
      }

      public class by_class
      {
        Establish c = () =>
        {
          factory_provider = depends.on<ICreateDependencyFactories>();
          items = new Dictionary<Type, ICreateADependency>();
          depends.on(items);
          the_factory = fake.an<ICreateADependency>();

          factory_provider.setup(x => x.create_factory_to_automatically_create(typeof(OurType))).Return(the_factory);
        };

        Because b = () =>
          sut.register<OurType>();

        It should_add_the_factory_that_can_create_the_type_into_the_dictionary = () =>
          items[typeof(OurType)].ShouldEqual(the_factory);

        static IDictionary<Type, ICreateADependency> items;
        static ICreateADependency the_factory;
        static ICreateDependencyFactories factory_provider;
      }
    }

    public class OurType : IOurType
    {
    }

    public interface IOurType
    {
    }
  }
}