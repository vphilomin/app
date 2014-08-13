using System.Collections.Generic;

namespace app.web.application.catalog_browsing
{
  public interface IFindDepartments 
  {
    IEnumerable<MainDepartmentLineItem> get_the_main_departments();
  }
}