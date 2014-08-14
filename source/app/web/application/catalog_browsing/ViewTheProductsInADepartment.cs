using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.aspnet;
using app.web.core;

namespace app.web.application.catalog_browsing
{
    public class ViewTheProductsInADepartment : ISupportAUserStory
    {
        private readonly IFindProductsInADepartment _productFinder;
        private readonly IDisplayInformation _displayEngine;

        public ViewTheProductsInADepartment()
            : this(new StubProductFinder(),
      new WebFormDisplayEngine())
    {
    }

        public ViewTheProductsInADepartment(IFindProductsInADepartment productFinder, IDisplayInformation displayEngine)
        {
            _productFinder = productFinder;
            _displayEngine = displayEngine;
        }

        public void process(IProvideRequestDetails request)
        {
            _displayEngine.display(_productFinder.get_products_of_department(request.map<ProductsInDepartmentInput>()));
        }
    }

    public class StubProductFinder : IFindProductsInADepartment
    {
        public IEnumerable<ProductInfoItem> get_products_of_department(ProductsInDepartmentInput input)
        {
            return Enumerable.Range(1,100).Select(x => new ProductInfoItem(){Name = "Product" + x});
        }
    }
}
