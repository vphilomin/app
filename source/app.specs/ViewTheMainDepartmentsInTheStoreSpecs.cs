using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewTheMainDepartments))]
  public class ViewTheMainDepartmentsSpecs
  {
    public abstract class concern : Observes<ISupportAUserStory,
      ViewTheMainDepartments>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayInformation>();
        department_finder = depends.on<IFindDepartments>();
        request = fake.an<IProvideRequestDetails>();
        main_departments = new List<MainDepartmentLineItem>();

        department_finder.setup(x => x.get_the_main_departments()).Return(main_departments);
      };

      Because b = () =>
        sut.process(request);

      It displays_the_departments = () =>
        display_engine.received(x => x.display(main_departments));

      static IFindDepartments department_finder;
      static IProvideRequestDetails request;
      static IDisplayInformation display_engine;
      static IEnumerable<MainDepartmentLineItem> main_departments;
    }
  }
}