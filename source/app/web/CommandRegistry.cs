using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace app.web
{
    public class CommandRegistry : IFindCommandsThatCanProcessRequests
    {
        IEnumerable<IProcessOneRequest> commands;

        public CommandRegistry(IEnumerable<IProcessOneRequest> commands)
        {
            this.commands = commands;
        }

        public IProcessOneRequest get_the_command_that_can_process(IProvideRequestDetails request)
        {
            return commands.FirstOrDefault(x => x.can_process(request));
        }
    }
}