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
        departments = depends.on<IFindDepartments>();
        request = fake.an<IProvideRequestDetails>();
      };

      Because b = () =>
        sut.process(request);

      It gets_a_list_of_the_main_departments_in_the_store = () =>
        departments.received(x => x.get_the_main_departments());

      static IFindDepartments departments;
      static IProvideRequestDetails request;
    }
  }
}