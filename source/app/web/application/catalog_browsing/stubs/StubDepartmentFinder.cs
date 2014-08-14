using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalog_browsing.stubs
{
  public class StubDepartmentFinder :IFindDepartments
  {
    public IEnumerable<MainDepartmentLineItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 1000).Select(x => new MainDepartmentLineItem
      {
        name = x.ToString("Department 0")
      });
    }

    public IEnumerable<MainDepartmentLineItem> get_department_using(DeparmentsInDepartmentInput input)
    {
      return Enumerable.Range(1, 1000).Select(x => new MainDepartmentLineItem
      {
        name = x.ToString("Sub Department 0")
      });
    }

  }
}