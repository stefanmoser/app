 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(RequestMatchBuilder))]  
  public class RequestMatchBuilderSpecs
  {
    public abstract class concern : Observes<IBuildRequestMatchers,
                                      RequestMatchBuilder>
    {
        
    }

   
    public class when_building_a_matcher_that_determines_whether_the_request_was_made_for_a_specific_input_model : concern
    {
      Establish c = () =>
      {
        request_that_should_match = fake.an<IContainRequestInformation>();
        request_that_should_match.setup(x => x.request_name).Return("{0}".format_using(typeof(OurRequest).Name));

        non_matching_request = fake.an<IContainRequestInformation>();
        non_matching_request.setup(x => x.request_name).Return(typeof(NotOurRequest).Name);
      };

      Because b = () =>
        result = sut.made_for<OurRequest>();

      It should_return_a_matcher_that_matches_whether_the_requests_name_is_the_name_of_the_request_model = () =>
      {
        result(request_that_should_match).ShouldBeTrue();
        result(non_matching_request).ShouldBeFalse();
      };

      static RequestMatch result;
      static IContainRequestInformation request_that_should_match;
      static IContainRequestInformation non_matching_request;
    }
  }

  class NotOurRequest
  {
  }

  class OurRequest
  {
  }
}
