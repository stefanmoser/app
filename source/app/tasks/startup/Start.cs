using System.Collections;

namespace app.tasks.startup
{
	public static class Start
	{
		public static IBuildStartupPipelines by<StartUpStepToRun>()
		{
			return new StartupStepBuilder(typeof(StartUpStepToRun));
		}
	}
}