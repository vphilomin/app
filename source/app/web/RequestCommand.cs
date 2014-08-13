namespace app.web
{
  public class RequestCommand : IProcessOneRequest
  {
      private readonly IMatchARequest matchARequest;

      public RequestCommand(IMatchARequest matchARequest)
      {
          this.matchARequest = matchARequest;
      }

      public void process(IProvideRequestDetails request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_process(IProvideRequestDetails request)
    {
        return matchARequest(request);
    }
  }
}