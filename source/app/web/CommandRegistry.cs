using System;
using System.Collections;
using System.Collections.Generic;

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
            foreach (var command in commands)
            {
                if (command.can_process(request))
                    return command;
            }

            throw new Exception();
        }
    }
}