namespace MarsRovers.CommandCenter
{
    using System.Collections.Generic;

    public class MarsRoverInstructions
    {
        public MarsRoverPosition RoverPosition { get; set; }
        public IList<RoverCommand> CommandInstructions { get; set; }
    }
}
