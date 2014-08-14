using app.web.application.catalog_browsing.stubs;
using app.web.aspnet;
using app.web.core;

namespace app.web.application.catalog_browsing
{
  public class ViewTheDepartmentsOfDepartment : ISupportAUserStory
  {
    IFindDepartments department_finder;
    IDisplayInformation display;

    public ViewTheDepartmentsOfDepartment(IFindDepartments department_finder, IDisplayInformation display)
    {
      this.department_finder = department_finder;
      this.display = display;
    }

    public ViewTheDepartmentsOfDepartment():this(new StubDepartmentFinder(),
      new WebFormDisplayEngine())
    {
    }

    public void process(IProvideRequestDetails request)
    {
      var input = request.map<DeparmentsInDepartmentInput>();
      var results = department_finder.get_department_using(input);

      display.display(results);
    }
  }

  public class DeparmentsInDepartmentInput
  {
  }

    public class ProductsInDepartmentInput
    {
        
    }
}