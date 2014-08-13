namespace app.web
{
  public class CommandRegistry : IFindCommandsThatCanProcessRequests
  {
    public IProcessOneRequest get_the_command_that_can_process(IProvideRequestDetails request)
    {
      throw new System.NotImplementedException();
    }
  }
}