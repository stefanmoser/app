using System;
using System.Collections.Generic;
using System.Linq;

namespace app.tasks.startup
{
  public class StartupStepBuilder : IBuildStartupPipelines
  {
    IList<Type> _steps;
    ICreateStartupSteps step_factory;

    public StartupStepBuilder(Type startup_type, IList<Type> types, ICreateStartupSteps step_factory)
    {
      _steps = types;
      this.step_factory = step_factory;
      _steps.Add(startup_type);
    }

    public IBuildStartupPipelines followed_by<StartupStepToRun>()
    {
      return new StartupStepBuilder(typeof(StartupStepToRun), _steps, step_factory);
    }

    public void finish_by<StartupStepToRun>()
    {
      _steps.Add(typeof(StartupStepToRun));
      run();
    }

    public void run()
    {
      _steps.Select(x => step_factory.create_step_from(x)).ToList()
        .ForEach(x => x.run());
    }
  }
}