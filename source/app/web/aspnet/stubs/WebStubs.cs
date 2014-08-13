using System;
using System.Web;
using System.Web.Compilation;
using app.web.core;

namespace app.web.aspnet.stubs
{
  public class WebStubs
  {
    public static ICreateAControllerRequest request_factory = (request) =>
    {
      return new StubRequest();
    };

    public static ICreateACommandWhenOneCantBeFound missing_command_factory = delegate
    {
      throw new NotImplementedException("You dont have a command to run this request");
    };

    public static ICreatePageInstances create_page = BuildManager.CreateInstanceFromVirtualPath;

    public class StubRequest : IProvideRequestDetails
    {
    }
  }
}