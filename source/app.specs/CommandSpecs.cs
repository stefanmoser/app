using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    public class CommandSpecs
    {
        public class concern : Observes<IProcessOneRequest,
            Command>
        {
        }

        public class when_checking_if_a_command_can_handle_a_request : concern
        {
            Establish e = () =>
            {
                the_request = fake.an<IContainRequestInformation>();
                request_matcher = depends.on<IMatchRequests>();
            };

            private Because b = () =>
                                can_handle_the_request = sut.can_handle(the_request);

            It should_check_if_the_request_matches = () =>
                    request_matcher.received(x => x.matches_request(the_request));

            private static IContainRequestInformation the_request;
            private static IMatchRequests request_matcher;
            private static bool can_handle_the_request;

            public class and_the_command_can_handle_the_request : when_checking_if_a_command_can_handle_a_request
            {
                Establish e = () => 
                    request_matcher.setup(x => x.matches_request(the_request)).Return(true);
                
                It should_be_able_to_handle_the_request = () =>
                    can_handle_the_request.ShouldBeTrue();
            }
        }
    }
}