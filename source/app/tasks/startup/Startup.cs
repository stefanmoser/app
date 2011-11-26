namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      Start.by_only_running<ConfiguringTheContainer>();
    }
  }
}