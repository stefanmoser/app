using System;
using System.Collections.Generic;

namespace app.tasks.startup
{
  public static class Start
  {
    public static Func<Type, IBuildStartupPipelines> builder_factory = (x) =>
    {
      return new StartupStepBuilder(x, new List<Type>(), new CreateStartupSteps());
    };

    public static IBuildStartupPipelines by<StartUpStepToRun>() where StartUpStepToRun : IRunAStartupStep
    {
      return builder_factory(typeof(StartUpStepToRun));
    }

    public static void by_only_running<T>()
    {
      by<NonStep>().finish_by<T>();
    }

    public class NonStep : IRunAStartupStep
    {
      IProvideContainerRegistrationServices registration;

      public NonStep(IProvideContainerRegistrationServices registration)
      {
        this.registration = registration;
      }

      public void run()
      {

      }
    }
  }
}