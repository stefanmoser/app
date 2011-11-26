using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Startup))]
  public class StartupSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_run : concern
    {
      Because b = () =>
        Startup.run();

      It should_have_configured_the_application_to_run = () =>
      {
        Container.fetch.an<IFetchDependencies>().ShouldNotBeNull();
        Container.fetch.an<IProcessRequests>().ShouldBeAn<FrontController>();
      };
    }
  }
}