namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      Start.by<ConfiguringTheContainer>()
        .followed_by<ConfigureTheServiceLayer>()
        .finish_by<ConfigureTheFrontController>();
    }
  }
}