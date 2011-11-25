using app.web.core.stubs;

namespace app.tasks.startup
{
  public class ConfigureTheServiceLayer : IRunAStartupStep
  {
    IProvideContainerRegistrationServices registration;

    public ConfigureTheServiceLayer(IProvideContainerRegistrationServices registration)
    {
      this.registration = registration;
    }

    public void run()
    {
      registration.register<GetDepartmentsInDepartment>();
      registration.register<GetProductsInADepartment>();
      registration.register<GetTheMainDepartments>();
    } 
  }
}