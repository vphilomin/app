using System.Collections.Generic;
using app.web.core;

namespace app.web.application.catalog_browsing
{
    public class View<Input, Output> : ISupportAUserStory
    {
        private IDisplayInformation display_engine;
        private IFind<Input, Output> finder;

        public View(IDisplayInformation display_engine, IFind<Input, Output> finder)
        {
            this.display_engine = display_engine;
            this.finder = finder;
        }

        public void process(IProvideRequestDetails request)
        {
            var input = request.map<Input>();
            IEnumerable<Output> items = finder.get(input);
            display_engine.display(items);
        }
    }
}