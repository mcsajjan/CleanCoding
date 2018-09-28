namespace MarsRovers.CommandCenter
{
    using System.Collections.Generic;

    public class MarsRoversCommandCenter
    {
        private MarsPlateu marsPlateu;
        private List<MarsRoverInstructions> MarsRoversCommands { get; set; }

        public MarsRoversCommandCenter()
        {
            this.MarsRoversCommands = new List<MarsRoverInstructions>();
        }

        public int NumberOfRovers { get; set; }

        public void CreateMarsPlateu(MarsPlateuSize marePlateuSize)
        {
            this.marsPlateu = new MarsPlateu(marePlateuSize.XcoOdinate, marePlateuSize.YcoOrdinate);
        }

        public void AddMarsRoverInstructions(MarsRoverInstructions marsRoverInstructions)
        {
            this.MarsRoversCommands.Add(marsRoverInstructions);
        }

        public IList<MarsRoverPosition> Execute()
        {
            this.CreateInstanceofRoversAndAddToMarshPlateu();
            return this.ExecuteCommands();
        }

        private void CreateInstanceofRoversAndAddToMarshPlateu()
        {
            foreach(MarsRoverInstructions roverCommand in MarsRoversCommands)
            {
                MarsRover marsRover = MarsRover.CreateRover(roverCommand.RoverPosition, this.marsPlateu);
                marsRover.InitialCommandInstructions = roverCommand.CommandInstructions;
                this.marsPlateu.AddRover(marsRover);
            }
        }

        private IList<MarsRoverPosition> ExecuteCommands()
        {
            this.marsPlateu.RunAllRovers();
            return this.marsPlateu.GetCurrentPositionOfRovers();
        }
    }
}
