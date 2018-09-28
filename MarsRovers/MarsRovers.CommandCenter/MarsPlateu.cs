
namespace MarsRovers.CommandCenter
{
    using System.Collections.Generic;

    public class MarsPlateu : MarsRovers.CommandCenter.MarsPlateuSize
    {
        public Dictionary<string, MarsRover> MarsRovers { get; set; }

        public MarsPlateu(int xCoOrdinate, int yCoOrdinate)
        {
            this.XcoOdinate = xCoOrdinate;
            this.YcoOrdinate = yCoOrdinate;
            this.MarsRovers = new Dictionary<string,MarsRover>();
        }

        public int XcoOdinate { get; set; }
        public int YcoOrdinate { get; set; }

        public void AddRover(MarsRover marsRover)
        {
            this.MarsRovers.Add(marsRover.CurrentPostionToString(), marsRover);
        }

        public void RunAllRovers()
        {
            MarsRover[] marsRovers = new MarsRover[this.MarsRovers.Values.Count];
            this.MarsRovers.Values.CopyTo(marsRovers,0);
            foreach (MarsRover marsRover in marsRovers)
            {
                marsRover.Run(marsRover.InitialCommandInstructions);
            }
        }

        public IList<MarsRoverPosition> GetCurrentPositionOfRovers()
        {
            IList<MarsRoverPosition> marsRoverPositions = new List<MarsRoverPosition>();
            foreach (MarsRover marsRover in this.MarsRovers.Values)
            {
                marsRoverPositions.Add(marsRover.GetCurrentPostionAndDirection());
            }

            return marsRoverPositions;
        }
    }
}
