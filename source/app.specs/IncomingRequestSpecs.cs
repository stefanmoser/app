 using Machine.Specifications;
 using app.utility.containers;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  public class IncomingRequestSpecs
  {
    public abstract class concern : Observes
    {
        
    }

   
    public class when_starting_to_build_a_request_match: concern
    {

      Establish c = () =>
      {
        the_builder = fake.an<IBuildRequestMatchers>();
        the_facade = fake.an<IFetchDependencies>();
        ContainerFacadeResolution resolution = () => the_facade;

        spec.change(() => Container.facade_resolution).to(resolution);

        the_facade.setup( x => x.an<IBuildRequestMatchers>()).Return(the_builder);
      };

      Because b = () =>
        result = IncomingRequest.was;

      It should_return_the_builder_that_can_be_used_to_create_matchers = () =>
        result.ShouldEqual(the_builder);

      static IBuildRequestMatchers result;
      static IBuildRequestMatchers the_builder;
      static IFetchDependencies the_facade;
    }
  }
}
