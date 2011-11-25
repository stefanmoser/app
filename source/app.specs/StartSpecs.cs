﻿using System;
using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
	[Subject(typeof(Start))]
	public class StartSpecs
	{
		public abstract class concern : Observes
		{

		}

		public class when_starting : concern
		{
			public class by_an_initial_startup_step : when_starting
			{
				Because b = () =>
					result = Start.by<InitialStep>();

				It should_return_a_startup_step_builder = () =>
					result.ShouldBeAn<IBuildStartupPipelines>();

				It should_add_the_step_to_the_list_of_steps = () =>
					result.steps.Count.ShouldEqual(1);

				static IBuildStartupPipelines result;
			};

			public class with_an_additional_startup_step : when_starting
			{
				Because b = () =>
					result = Start.by<InitialStep>().followed_by<SecondStep>();

				It should_return_a_startup_step_builder = () =>
					result.ShouldBeAn<IBuildStartupPipelines>();

				It should_add_both_steps_to_the_list = () =>
					result.steps.Count.ShouldEqual(2);

				static IBuildStartupPipelines startup_builder;
				static IBuildStartupPipelines result;
			};

			public class with_the_finish_by_step : when_starting
			{
				Establish c = () =>
				{

				};

				Because b = () =>
					Start.by<InitialStep>().followed_by<SecondStep>().finish_by<last_step>();

				It should_have_run_all_the_startup_step = () =>
				{

				};

				static IBuildStartupPipelines startup_builder;
			};
		}
	}

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
}
