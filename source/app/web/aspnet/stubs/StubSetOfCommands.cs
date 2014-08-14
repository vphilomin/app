using System.Collections;
using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;

namespace app.web.aspnet.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return new RequestCommand(x => true, new ViewTheProductsInADepartment());
      yield return new RequestCommand(x => true, new ViewTheDepartmentsOfDepartment());
      yield return new RequestCommand(x => true, new ViewTheMainDepartments());
    }
  }
}