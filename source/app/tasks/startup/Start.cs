using System;
using System.Collections;
using System.Collections.Generic;

namespace app.tasks.startup
{
	public static class Start
	{
		public static IBuildStartupPipelines by<StartUpStepToRun>()
		{
			return new StartupStepBuilder(typeof(StartUpStepToRun));
		}
	}

	public class StartupStepBuilder : IBuildStartupPipelines
	{
		IList<Type> _steps;

		public StartupStepBuilder(Type StartupTypeToRun)
		{
			_steps = new List<Type>();
			_steps.Add(StartupTypeToRun);
		}

		public void run()
		{
			throw new NotImplementedException();
		}

		public IList<Type> steps
		{
			get { return _steps; }
		}

		public IBuildStartupPipelines followed_by<StartupStepToRun>()
		{
			
		}

		public void finish_by<StartupStepToRun>()
		{
			throw new NotImplementedException();
		}
	}
}