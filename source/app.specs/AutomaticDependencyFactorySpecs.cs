 using System.Data;
 using System.Reflection;
 using Machine.Specifications;
 using app.specs.utility;
 using app.utility.containers;
 using app.utility.containers.basic;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(AutomaticDependencyFactory))]  
  public class AutomaticDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateADependency,
                                      AutomaticDependencyFactory>
    {
        
    }

   
    public class when_creating_a_dependency : concern
    {
      Establish c = () =>
      {
        connection = fake.an<IDbConnection>();
        command = fake.an<IDbCommand>();
        reader = fake.an<IDataReader>();
        container = depends.on<IFetchDependencies>();
        depends.on(typeof(OurTypeWithDependencies));
        constructor_selection_strategy = depends.on<IPickTheConstructorForAType>();

        ctor = ObjectFactory.expressions.to_target<OurTypeWithDependencies>().get_ctor(() => new OurTypeWithDependencies(null,null,null));

        constructor_selection_strategy.setup(x => x.get_applicable_constructor_on(typeof(OurTypeWithDependencies))).Return(
          ctor);

        container.setup(x => x.an(typeof(IDbCommand))).Return(command);
        container.setup(x => x.an(typeof(IDbConnection))).Return(connection);
        container.setup(x => x.an(typeof(IDataReader))).Return(reader);

      };

      Because b = () =>
        result = sut.create();

      It should_return_the_instance_with_all_dependencies_populated = () =>
      {
        var item = result.ShouldBeAn<OurTypeWithDependencies>()
        item.command.ShouldEqual(the_command);
        item.connection.ShouldEqual(connection);
        item.reader.ShouldEqual(reader);
      };

      static object result;
      static IDbCommand the_command;
      static IDbConnection connection;
      static IDataReader reader;
      static IFetchDependencies container;
      static IDbCommand command;
      static IPickTheConstructorForAType constructor_selection_strategy;
      static ConstructorInfo ctor;
    }

    public class OurTypeWithDependencies
    {
      public IDbConnection connection;
      public IDbCommand command;
      public IDataReader reader;

      public OurTypeWithDependencies(IDbConnection connection, IDbCommand command, IDataReader reader)
      {
        this.connection = connection;
        this.command = command;
        this.reader = reader;
      }

      public OurTypeWithDependencies(IDbConnection connection)
      {
        this.connection = connection;
      }

      public OurTypeWithDependencies(IDbCommand command, IDbConnection connection)
      {
        this.command = command;
        this.connection = connection;
      }
    }
  }

}
