using System;
using System.Data.SqlClient;
using Machine.Specifications;
using app.utility.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(SimpleFactory))]
  public class SimpleFactorySpecs
  {
    public abstract class concern : Observes<ICreateADependency,
                                      SimpleFactory>
    {
    }

    public class when_creating_a_dependency : concern
    {
      Establish c = () =>
      {
        the_connection = new SqlConnection();
        depends.on<Func<object>>(() => the_connection);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_instance_using_its_configured_delegate = () =>
        result.ShouldEqual(the_connection);

      static object result;
      static SqlConnection the_connection;
    }
  }
}