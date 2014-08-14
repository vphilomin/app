using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
    [Subject(typeof(View<ProductsInDepartmentInput, ProductInfoItem>))]
    public class ViewSpecs
    {
        public abstract class concern : Observes<ISupportAUserStory,
          View<ProductsInDepartmentInput, ProductInfoItem>>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                display_engine = depends.on<IDisplayInformation>();
                product_finder = depends.on<IFind<ProductsInDepartmentInput, ProductInfoItem>>();
                input = new ProductsInDepartmentInput();
                request = fake.an<IProvideRequestDetails>();
                request.setup(x => x.map<ProductsInDepartmentInput>()).Return(input);
                products = new List<ProductInfoItem>();

                product_finder.setup(x => x.get(input)).Return(products);
            };

            Because b = () =>
              sut.process(request);

            It displays_the_products_of_the_chosen_department = () =>
              display_engine.received(x => x.display(products));

            static IFind<ProductsInDepartmentInput, ProductInfoItem> product_finder;
            static IProvideRequestDetails request;
            static IDisplayInformation display_engine;
            static IEnumerable<ProductInfoItem> products;
            static ProductsInDepartmentInput input;
        }
    }
}