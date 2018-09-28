namespace MarsRovers.CommandCenter.Tests
{
    public class MarsRoverPositionMock : MarsRoverPosition
    {
        public MarsRoverPositionMock(int xCoOridane, int yCoOrdinate, NavigationDirection directionOfRover)
        {
            this.CurrentPositionXCoOridante = xCoOridane;
            this.CurrentPositionYCoOrdinate = yCoOrdinate;
            this.CurrentDirectionOfRover = directionOfRover;
        }

        public NavigationDirection CurrentDirectionOfRover { get; set; }
        public int CurrentPositionXCoOridante { get; set; }
        public int CurrentPositionYCoOrdinate { get; set; }
    }
}
