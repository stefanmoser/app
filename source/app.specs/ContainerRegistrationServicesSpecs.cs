using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

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

    public class when_getting_a_factory_for_a_dependency :concern_for_lookup
    {
      
    }
    public class when_registering_an_item : concern_for_registration
    {
      public class by_contract_and_implementation
      {
        Establish c = () =>
        {
          factory_provider = depends.on<ICreateDependencyFactories>();
          items  = new Dictionary<Type, ICreateADependency>();
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
          items  = new Dictionary<Type, ICreateADependency>();
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
          items  = new Dictionary<Type, ICreateADependency>();
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