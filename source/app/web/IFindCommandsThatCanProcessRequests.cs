namespace app.web
{
  public interface IFindCommandsThatCanProcessRequests
  {
    IProcessOneRequest get_the_command_that_can_process(IProvideRequestDetails request);
  }
}