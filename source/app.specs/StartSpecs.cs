using System;
using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using app.tasks.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Start))]
  public class StartSpecs
  {
    class last_step : IRunAStartupStep
    {
      public void run()
      {
      }
    }

    class SecondStep : IRunAStartupStep
    {
      public void run()
      {
      }
    }

    class InitialStep : IRunAStartupStep
    {
      public void run()
      {
      }
    }

    public abstract class concern : Observes
    {
    }

    public abstract class concern_for_builder : Observes<IBuildStartupPipelines, StartupStepBuilder>
    {
      Establish c = () =>
      {
        depends.on(typeof(InitialStep));
      };
    }

    public class by_an_initial_startup_step : concern
    {
      Establish c = () =>
      {
        builder = fake.an<IBuildStartupPipelines>();
        Func<Type, IBuildStartupPipelines> factory = x =>
        {
          x.ShouldEqual(typeof(InitialStep));
          return builder;
        };
        spec.change(() => Start.builder_factory).to(factory);
      };

      Because b = () =>
        result = Start.by<InitialStep>();

      It should_return_a_startup_step_builder = () =>
        result.ShouldEqual(builder);

      static IBuildStartupPipelines result;
      static IBuildStartupPipelines builder;
    };

    public class when_adding_a_new_step : concern_for_builder
    {
      Establish c = () =>
      {
        all_types = new List<Type>();
        depends.on(all_types);
      };

      Because b = () =>
        result = sut.followed_by<SecondStep>();

      It should_return_a_startup_step_builder = () =>
        result.ShouldBeAn<IBuildStartupPipelines>().ShouldNotEqual(sut);

      It should_add_both_steps_to_the_list = () =>
        all_types.ShouldContain(typeof(SecondStep));

      static IBuildStartupPipelines result;
      static IList<Type> all_types;
    };

    public class with_the_finish_by_step : concern_for_builder
    {
      Establish c = () =>
      {
        types = new List<Type>();
        types.Add(typeof(SecondStep));
        step_factory = depends.on<ICreateStartupSteps>();
        the_step = fake.an<IRunAStartupStep>();
        depends.on(types);

        step_factory.setup(x => x.create_step_from(Arg<Type>.Is.Anything)).Return(the_step);
      };

      Because b = () =>
        sut.finish_by<last_step>();

      It should_have_run_all_the_startup_step = () =>
        the_step.received(x => x.run()).Times(3);

      static IBuildStartupPipelines startup_builder;
      static IList<Type> types;
      static ICreateStartupSteps step_factory;
      static IRunAStartupStep the_step;
    };
  }
}