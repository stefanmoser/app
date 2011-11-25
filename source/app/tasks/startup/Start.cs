namespace app.tasks.startup
{
  public class Start
  {
    public static BuildStartUpSteps by<StartUpStep>() where StartUpStep : IRunAStartupStep
    {
      var b = new BuildStartUpSteps();
      b.AddStep<StartUpStep>();
      return b;
    }
  }
}