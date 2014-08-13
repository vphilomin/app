using System.Collections.Generic;
using System.Linq;
using app.web.aspnet.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommandsThatCanProcessRequests
  {
    IEnumerable<IProcessOneRequest> commands;
    ICreateACommandWhenOneCantBeFound missing_command_factory;

    public CommandRegistry(IEnumerable<IProcessOneRequest>  commands, ICreateACommandWhenOneCantBeFound missing_command_factory)
    {
      this.commands = commands;
      this.missing_command_factory = missing_command_factory;
    }

    public CommandRegistry():this(new StubSetOfCommands(), WebStubs.missing_command_factory)
    {
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideRequestDetails request)
    {
      return commands.FirstOrDefault(x => x.can_process(request)) ?? missing_command_factory(request);
    }
  }
}