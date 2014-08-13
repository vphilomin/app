using app.web.core;

namespace app.web.application.catalog_browsing
{
    public class ViewTheMainDepartments : ISupportAUserStory
    {
        private readonly IFindDepartments findDepartments;

        public ViewTheMainDepartments(IFindDepartments findDepartments)
        {
            this.findDepartments = findDepartments;
        }

        public void process(IProvideRequestDetails request)
        {
            findDepartments.get_the_main_departments();
        }
    }
}