using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.basic_container;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
	[Subject(typeof (GetTheFactoryForADependency))]
	public class GetTheFactoryForADependencySpecs
	{
		public abstract class concern : Observes<IGetTheFactoryForADependency, GetTheFactoryForADependency>
		{
		}

		public class when_getting_a_factory_from_the_registry : concern
		{
			private Establish c = () =>
			{
				the_type = typeof (SomeObject);

				my_dependency_factory = fake.an<ICreateOneDependency>();
				my_dependency_factory.setup(x => x.can_create(the_type)).Return(true);
				var list = new List<ICreateOneDependency>();
				list.Add(my_dependency_factory);

				depends.on<IEnumerable<ICreateOneDependency>>(list);
			};

			private Because b = () =>
			{
				result = sut.get_the_factory_that_can_create(the_type);
			};

			private It creates_a_factory_for_the_type = () =>
			{
				result.ShouldEqual(my_dependency_factory);
			};

			private static Type the_type;
			private static ICreateOneDependency result;
			private static ICreateOneDependency my_dependency_factory;
		}

		private class SomeObject
		{
		}
	}
}
