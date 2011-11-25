using app.utility.containers;

namespace app.web.core
{
  public class IncomingRequest
  {
    public static IBuildRequestMatchers was
    {
      get { return Container.fetch.an<MatchBuilderFactory>().Invoke(); }
    }
  }
}