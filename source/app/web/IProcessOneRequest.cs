namespace app.web
{
  public interface IProcessOneRequest
  {
    void process(IProvideRequestDetails request);
    bool can_process(IProvideRequestDetails request);
  }
}