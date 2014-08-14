using System;
using app.container;

namespace app.structuremap_container
{
  public class StructureMapContainer : IFetchDependencies
  {
    public Dependency an<Dependency>()
    {
      throw new System.NotImplementedException();
    }

    public object an(Type type)
    {
      throw new NotImplementedException();
    }
  }
}