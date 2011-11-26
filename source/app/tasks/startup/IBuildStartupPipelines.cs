using app.tasks.startup;

public interface IBuildStartupPipelines : IRunAStartupStep
{
  IBuildStartupPipelines followed_by<StartupStepToRun>();
  void finish_by<StartupStepToRun>();
}