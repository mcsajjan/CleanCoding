namespace MarsRovers
{
    using MarsRovers.CommandCenter;
    using System.Collections.Generic;
    using System.Text;

    public class MarsRoverParser : MarsRoverPosition
    {
        public MarsRoverParser(string roverPosition)
        {
            this.SetXYCoOrdinatePosition(roverPosition);
        }

        public NavigationDirection CurrentDirectionOfRover { get; set; }
        public int CurrentPositionXCoOridante { get; set; }
        public int CurrentPositionYCoOrdinate { get; set; }

        private void SetXYCoOrdinatePosition(string roverPostion)
        {
            var splittedRoverPositions = roverPostion.Split(' ');
            this.CurrentPositionXCoOridante = int.Parse(splittedRoverPositions[0]);
            this.CurrentPositionYCoOrdinate = int.Parse(splittedRoverPositions[1]);
            this.CurrentDirectionOfRover = NavigationDirectionUtility.GetNavigationType(splittedRoverPositions[2]);
        }

        public static string GetMarsRoverPositions(IList<MarsRoverPosition> marsRoverPositions)
        {
            StringBuilder currentPositions = new StringBuilder();

            foreach (var marsRoverPosition in marsRoverPositions)
            {
                currentPositions.Append(marsRoverPosition.CurrentPositionXCoOridante).Append(" ")
                    .Append(marsRoverPosition.CurrentPositionYCoOrdinate).Append(" ")
                    .Append(NavigationDirectionUtility.GetStringValue(marsRoverPosition.CurrentDirectionOfRover));
                currentPositions.Append(System.Environment.NewLine);
            }

            return currentPositions.ToString().Substring(0, currentPositions.Length - 2);
        }

    }
}
