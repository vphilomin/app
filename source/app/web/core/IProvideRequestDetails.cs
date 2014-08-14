using System.Security.Cryptography.X509Certificates;

namespace app.web.core
{
  public interface IProvideRequestDetails
  {
     T provide_request_details<T>();
  }

    public interface IProvideRequestDetailsOnADepartment
    {
        string get_department_name();
    }
}