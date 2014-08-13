using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommandsThatCanProcessRequests
  {
    private IEnumerable<IProcessOneRequest> commands;

    public CommandRegistry(IEnumerable<IProcessOneRequest>  commands)
    {
      this.commands = commands;
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideRequestDetails request)
    {
      return commands.First(x => x.can_process(request));
    }
  }
}