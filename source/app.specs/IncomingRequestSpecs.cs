 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;

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
        MatchBuilderFactory factory = () => the_builder;

        spec.change(() => IncomingRequest.builder_factory).to(factory);
      };

      Because b = () =>
        result = IncomingRequest.was;

      It should_return_the_builder_that_can_be_used_to_create_matchers = () =>
        result.ShouldEqual(the_builder);

      static IBuildRequestMatchers result;
      static IBuildRequestMatchers the_builder;
    }
  }
}
