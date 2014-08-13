using System.Web;
using app.web.core;

namespace app.web.aspnet
{
  public class WebFormDisplayEngine : IDisplayInformation
  {
    ICreateViewsThatCanDisplayAReport view_factory;
    IGetTheCurrentHttpContext current_context;

    public WebFormDisplayEngine(IGetTheCurrentHttpContext current_context,
      ICreateViewsThatCanDisplayAReport view_factory)
    {
      this.current_context = current_context;
      this.view_factory = view_factory;
    }

    public WebFormDisplayEngine():this(() => HttpContext.Current,
      new WebFormFactory())
    {
    }

    public void display<ReportModel>(ReportModel model)
    {
      var view = view_factory.create_view_to_display(model);
      view.ProcessRequest(current_context());
    }
  }
}