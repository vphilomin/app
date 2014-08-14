namespace app.startup
{
  public interface IProvideStartupServices
  {
    void register<Contract, Implementation>();
    void register<Contract>(Contract instance);
  }
}