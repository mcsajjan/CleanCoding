namespace MarsRovers
{
    using System;
    using MarsRovers.CommandCenter;

    public class Program
    {
        private static MarsRoversCommandCenter command;

        public static void Main(string[] args)
        {
            DisplayCommand("****** Welcome to Mars Rovers command center ******");
            command = new MarsRoversCommandCenter();
            GetCoOridnatesOfMarsPlateu();
            GetTotalNumberOfRovers();
            SendCommandsToRovers();
            DisplayCommand("****** Current Position Of Rovers ********");
            DisplayCommand(MarsRoverParser.GetMarsRoverPositions(command.Execute()));
            Console.ReadLine();
        }

        private static void GetCoOridnatesOfMarsPlateu()
        {
            DisplayCommand("Enter the co-ordinates of the Mars plateu");
            MarsPlateuSize marsPlateSize = new MarsPlateuSizeParser(Console.ReadLine());
            command.CreateMarsPlateu(marsPlateSize);
        }

        private static void GetTotalNumberOfRovers()
        {
            DisplayCommand("Enter total number of Rovers");
            command.NumberOfRovers = int.Parse(Console.ReadLine());
        }

        private static void SendCommandsToRovers()
        {
            DisplayCommand("Send commands to rovers");
            MarsRoverInstructions roverCommand;
            for (int indexer = 0; indexer < command.NumberOfRovers; indexer++)
            {
                roverCommand = new MarsRoverInstructions();
                roverCommand.RoverPosition = new MarsRoverParser(Console.ReadLine());
                roverCommand.CommandInstructions = RoverCommandUtility.GetRoverCommands(Console.ReadLine());
                command.AddMarsRoverInstructions(roverCommand);
            }
        }

        private static void DisplayCommand(string command)
        {
            Console.WriteLine(command);
        }
    }
}
