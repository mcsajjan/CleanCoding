namespace MarsRovers
{
    using System;
    using System.Collections.Generic;
    using MarsRovers.CommandCenter;

    public class RoverCommandUtility
    {
        public static IList<RoverCommand> GetRoverCommands(string commandInstruction)
        {
            IList<RoverCommand> roverCommands = new List<RoverCommand>();
            char[] commands = commandInstruction.ToCharArray();
            foreach (char command in commands)
            {
                roverCommands.Add(RoverCommandUtility.ParseCommand(command));
            }
            return roverCommands;
        }

        private static RoverCommand ParseCommand(char roverCommand)
        {
            switch (roverCommand)
            {
                case 'L':
                    return RoverCommand.Left;
                case 'R':
                    return RoverCommand.Right;
                case 'M':
                    return RoverCommand.Move;
                default:
                    throw new ApplicationException();
            }
        }
    }
}
