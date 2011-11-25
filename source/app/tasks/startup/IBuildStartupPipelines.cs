using System;
using System.Collections.Generic;
using app.tasks.startup;

public interface IBuildStartupPipelines : IRunAStartupStep
{
	IList<Type> steps { get; }

	IBuildStartupPipelines followed_by<StartupStepToRun>();
	void finish_by<StartupStepToRun>();
}
