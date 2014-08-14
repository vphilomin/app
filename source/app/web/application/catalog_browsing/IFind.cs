using System.Collections.Generic;

namespace app.web.application.catalog_browsing
{
    public interface IFind<in Input, out Output>
    {
        IEnumerable<Output> get(Input input);
    }
}