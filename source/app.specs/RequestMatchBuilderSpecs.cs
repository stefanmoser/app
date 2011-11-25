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
        data_bag = fake.an<IContainRequestInformation>();
        data_bag.setup(x => x.request_name).Return("{0}".format_using(typeof(OurRequest).Name));

        other_bag = fake.an<IContainRequestInformation>();
        other_bag.setup(x => x.request_name).Return(typeof(NotOurRequest).Name);
      };

      Because b = () =>
        result = sut.made_for<OurRequest>();

      It should_return_a_matcher_that_matches_whether_the_requests_name_is_the_name_of_the_request = () =>
      {
        result(data_bag).ShouldBeTrue();
        result(other_bag).ShouldBeFalse();

      };

      static ContainsTheModel result;
      static IContainRequestInformation data_bag;
      static IContainRequestInformation other_bag;
    }
  }

  class NotOurRequest
  {
  }

  class OurRequest
  {
  }
}
