using System;
namespace app.web.core
{
  public class IncomingRequest
  {
    public static MatchBuilderFactory builder_factory = () =>
    {
      throw new NotImplementedException("This needs to be configured at startup"); 
    };

    public static IBuildRequestMatchers was
    {
      get { return builder_factory();}
    }
  }
}