using System.Data;
using System.Reflection;
using Machine.Specifications;
using app.specs.utility;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(GreedyConstructorSelectionStrategy))]
  public class GreedyConstructorSelectionStrategySpecs
  {
    public abstract class concern : Observes<IPickTheConstructorForAType,
                                      GreedyConstructorSelectionStrategy>
    {
    }

    public class when_finding_the_ctor_on_a_type : concern
    {
      Establish c = () =>
      {
        the_ctor_with_most = ObjectFactory.expressions.to_target<OurType>().get_ctor(() => new OurType(null, null, null));
      };
      Because b = () =>
        result = sut.get_applicable_constructor_on(typeof(OurType));

      It should_return_the_ctor_with_most_arguments = () =>
        result.ShouldEqual(the_ctor_with_most);

      static ConstructorInfo result;
      static ConstructorInfo the_ctor_with_most;
    }

    public class OurType
    {
      IDbConnection connection;
      IDbCommand command;
      IDataReader reader;

      public OurType(IDbConnection connection, IDbCommand command, IDataReader reader)
      {
        this.connection = connection;
        this.command = command;
        this.reader = reader;
      }

      public OurType(IDbConnection connection)
      {
        this.connection = connection;
      }

      public OurType(IDbConnection connection, IDbCommand command)
      {
        this.connection = connection;
        this.command = command;
      }
    }
  }
}
