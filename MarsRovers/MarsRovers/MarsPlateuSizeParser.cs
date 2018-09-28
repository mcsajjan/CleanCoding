namespace MarsRovers
{
    using MarsRovers.CommandCenter;

    public class MarsPlateuSizeParser : MarsPlateuSize
    {
        public MarsPlateuSizeParser(string marsPlateuCoOridnates)
        {
            string[] coOrdinates = marsPlateuCoOridnates.Split(' ');
            this.XcoOdinate = int.Parse(coOrdinates[0]);
            this.YcoOrdinate = int.Parse(coOrdinates[1]);
        }

        public int XcoOdinate { get; set; }
        public int YcoOrdinate { get; set; }
    }
}
