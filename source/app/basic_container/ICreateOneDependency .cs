using System;

namespace app.basic_container
{
	public interface ICreateOneDependency
	{
		object create();
		bool can_create(Type type);
	}
}