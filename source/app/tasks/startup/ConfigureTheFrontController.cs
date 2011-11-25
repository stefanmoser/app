using System.Web;
using System.Web.Compilation;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class ConfigureTheFrontController : IRunAStartupStep
  {
    IProvideContainerRegistrationServices registration;

    public ConfigureTheFrontController(IProvideContainerRegistrationServices registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      registration.register<IBuildRequestMatchers, RequestMatchBuilder>();
      registration.register<IFindPathsToViews, StubPathRegistry>();
      registration.register_instance<CurrentContextResolver>(() => HttpContext.Current);
      registration.register<ICreateAResponse, PageFactory>();
      registration.register_instance<TemplateFactory>(BuildManager.CreateInstanceFromVirtualPath);
      registration.register<IDisplayReportModels, WebResponseEngine>();
      registration.register<IFindCommands, CommandRegistry>();
      registration.register<ICreateRequests, StubRequestFactory>();
      registration.register<IProcessRequests, FrontController>();
    }
  }
}