using System;
using Machine.Specifications;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyCreationException))]
  public class DependencyCreationExceptionSpecs
  {
    public abstract class concern : Observes<Exception,
                                      DependencyCreationException>
    {
    }

    public class when_asked_for_its_message : concern
    {
      Establish c = () =>
      {
        depends.on(typeof(OurType));
      };

      Because b = () =>
        result = sut.Message;

      It should_return_a_message_that_contains_details_about_the_type_that_could_not_be_created = () =>
        result.ShouldContain(typeof(OurType).Name);

      static string result;
    }

    public class OurType
    {
    }
  }
}
