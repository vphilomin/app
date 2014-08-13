using app.web.application.catalog_browsing.stubs;
using app.web.aspnet;
using app.web.core;

namespace app.web.application.catalog_browsing
{
  public class ViewTheMainDepartments : ISupportAUserStory
  {
    IFindDepartments department_finder;
    IDisplayInformation display_engine;

    public ViewTheMainDepartments(IFindDepartments department_finder, IDisplayInformation display_engine)
    {
      this.department_finder = department_finder;
      this.display_engine = display_engine;
    }

    public ViewTheMainDepartments() : this(new StubDepartmentFinder(),
      new WebFormDisplayEngine())
    {
    }

    public void process(IProvideRequestDetails request)
    {
      var departments = department_finder.get_the_main_departments();
      display_engine.display(departments);
    }
  }
}