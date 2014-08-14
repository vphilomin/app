using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.basic_container
{
	public class GetTheFactoryForADependency : IGetTheFactoryForADependency
	{
		public ICreateOneDependency get_the_factory_that_can_create(Type type)
		{
			throw new NotImplementedException();
		}
	}
}
