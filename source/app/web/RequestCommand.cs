namespace app.web
{
  public class RequestCommand : IProcessOneRequest
  {
    public void process(IProvideRequestDetails request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_process(IProvideRequestDetails request)
    {
      throw new System.NotImplementedException();
    }
  }
}