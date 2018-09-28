namespace MarsRovers
{
    using MarsRovers.CommandCenter;
    public class NavigationDirectionUtility
    {
        public static NavigationDirection GetNavigationType(string navigationKey)
        {
            switch (navigationKey.ToUpperInvariant())
            {
                case "E":
                    return NavigationDirection.East;
                case "W":
                    return NavigationDirection.West;
                case "S":
                    return NavigationDirection.South;
                case "N":
                    return NavigationDirection.North;
                default:
                    //TODO: Throw exception
                    throw new System.Exception();
            }
        }

        public static string GetStringValue(NavigationDirection navigationDirection)
        {
            switch (navigationDirection)
            {
                case NavigationDirection.East:
                    return "E";
                case NavigationDirection.West:
                    return "W";
                case NavigationDirection.North:
                    return "N";
                case NavigationDirection.South:
                    return "S";
                default:
                    // TODO
                    throw new System.Exception();
            }
        }
    }
}
