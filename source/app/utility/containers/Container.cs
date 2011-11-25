using System;
namespace app.utility.containers
{
  public class Container
  {
    public static ContainerFacadeResolution facade_resolution = () =>
    {
      throw new NotImplementedException("This should be configured at startup");
    };

    public static IFetchDependencies fetch
    {
		get { return facade_resolution(); }
    }
  }
}