namespace MarsRovers.CommandCenter
{
    public interface MarsRoverPosition
    {
        NavigationDirection CurrentDirectionOfRover { get; set; }
        int CurrentPositionXCoOridante { get; set; }
        int CurrentPositionYCoOrdinate { get; set; }
    }
}
