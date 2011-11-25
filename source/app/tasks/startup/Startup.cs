using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility.containers;
using app.utility.containers.basic;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup
{
	public class Startup
	{
		static IDictionary<Type, ICreateADependency> dependencies;
		static IFetchDependencies container;

		public static void run()
		{
			wire_everything_up();
		}

		static void wire_everything_up()
		{
			register_container();
			register_service_layer();
			register_net_layer();
			register_command_layer();
		}

		static void register_container()
		{
			dependencies = new Dictionary<Type, ICreateADependency>();
			container = new DependencyContainer(dependencies);
			ContainerFacadeResolution facade_resolution = () => container;
			Container.facade_resolution = facade_resolution;
			register_instance(container);
		}

		static void register_command_layer()
		{
			register<IFindCommands, CommandRegistry>();
			register<ICreateRequests, StubRequestFactory>();
			register<IProcessRequests, FrontController>();
		}

		static void register_net_layer()
		{
			register<IBuildRequestMatchers, RequestMatchBuilder>();
			register<IFindPathsToViews, StubPathRegistry>();
			register_instance<CurrentContextResolver>(() => HttpContext.Current);
			register<ICreateAResponse, PageFactory>();
			register_instance<TemplateFactory>(BuildManager.CreateInstanceFromVirtualPath);
			register<IDisplayReportModels, WebResponseEngine>();
		}

		static void register_service_layer()
		{
			register<GetDepartmentsInDepartment>();
			register<GetProductsInADepartment>();
			register<GetTheMainDepartments>();
		}



		static void register<Implementation>()
		{
			register<Implementation, Implementation>();
		}
		static void register<Contract, Implementation>() where Implementation : Contract
		{
			dependencies.Add(typeof(Contract), new AutomaticDependencyFactory(container, new GreedyConstructorSelectionStrategy(), typeof(Implementation)));
		}
		static void register_instance<RegisteredType>(RegisteredType item)
		{
			dependencies.Add(typeof(RegisteredType), new SimpleFactory(() => item));
		}
	}
}
