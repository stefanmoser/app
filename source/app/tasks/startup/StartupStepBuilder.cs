using System;
using System.Collections.Generic;

namespace app.tasks.startup
{
	public class StartupStepBuilder : IBuildStartupPipelines
	{
		IList<Type> _steps;
		public IList<Type> steps
		{
			get { return _steps; }
		}


		public StartupStepBuilder(Type StartupTypeToRun) : this(StartupTypeToRun, new List<Type>())
		{
		}

		StartupStepBuilder(Type StartupTypeToRun, IList<Type> types)
		{
			_steps = types;
			_steps.Add(StartupTypeToRun);
		}

		public IBuildStartupPipelines followed_by<StartupStepToRun>()
		{
			return new StartupStepBuilder(typeof(StartupStepToRun), _steps);
		}

		public void finish_by<StartupStepToRun>()
		{
			_steps.Add(typeof(StartupStepToRun));
			run();
		}

		public void run()
		{
			foreach(Type step in _steps)
				((IRunAStartupStep) Activator.CreateInstance(step)).run();
		}

	}
}