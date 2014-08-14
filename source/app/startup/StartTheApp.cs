namespace app.startup
{
  public class StartTheApp
  {
    public static void by<StartupStep>() where StartupStep  : IRunAStartupStep
    {
      throw new System.NotImplementedException();
    }
  }
}