using System.Collections.Generic;

namespace app.web.application.catalog_browsing
{
  public interface IFindDepartments 
  {
    IEnumerable<MainDepartmentLineItem> get_the_main_departments();
      IEnumerable<MainDepartmentLineItem> get_departments_of_department_specified_by_name(string name);
  }
}