using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalog_browsing.stubs
{
  public class StubProductFinder : IFindProductsInADepartment
  {
    public IEnumerable<ProductInfoItem> get_products_of_department(ProductsInDepartmentInput input)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductInfoItem() {name = "Product" + x});
    }
  }
}