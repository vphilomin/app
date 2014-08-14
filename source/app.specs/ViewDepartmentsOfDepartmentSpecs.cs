using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsOfDepartment))]
  public class ViewDepartmentsOfDepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserStory,
      ViewTheDepartmentsOfDepartment>
    {
    }

   

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayInformation>();
        department_finder = depends.on<IFindDepartments>();
        request = fake.an<IProvideRequestDetails>();
          request.setup(x => x.provide_request_details<string>()).Return("department");
        departments = new List<MainDepartmentLineItem>();

        department_finder.setup(x => x.get_the_main_departments()).Return(departments);
      };

      Because b = () =>
        sut.process(request);

      It displays_the_departments_of_the_chosen_department = () =>
        display_engine.received(x => x.display(departments));

      static IFindDepartments department_finder;
      static IProvideRequestDetails request;
      static IDisplayInformation display_engine;
      static IEnumerable<MainDepartmentLineItem> departments;
    }
  }
}