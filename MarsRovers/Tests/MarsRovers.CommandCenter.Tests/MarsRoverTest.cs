namespace MarsRovers.CommandCenter.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class MarsRoverTest
    {
        MarsRover marsRover;
        IList<RoverCommand> roverCommands;

        [TestMethod]
        public void CanaryTest()
        {
            Assert.IsTrue(true);
        }

        [TestInitialize]
        public void InitializeVariables()
        {
            this.marsRover = this.GetDefaultRover();
            this.roverCommands = new List<RoverCommand>();
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction R")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionR()
        {
            roverCommands.Add(RoverCommand.Right);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(1, 2, NavigationDirection.East);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }


        [Description("Rum Mars rover for the initial position 12N and commandinstruction L")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionL()
        {
            roverCommands.Add(RoverCommand.Left);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(1, 2, NavigationDirection.West);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction M")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionM()
        {
            roverCommands.Add(RoverCommand.Move);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(1, 3, NavigationDirection.North);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction MM")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionMM()
        {
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(1, 4, NavigationDirection.North);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction LL")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionLL()
        {
            roverCommands.Add(RoverCommand.Left);
            roverCommands.Add(RoverCommand.Left);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(1, 2, NavigationDirection.South);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction RR")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionRR()
        {
            roverCommands.Add(RoverCommand.Right);
            roverCommands.Add(RoverCommand.Right);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(1, 2, NavigationDirection.South);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction LMR")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionLMR()
        {
            roverCommands.Add(RoverCommand.Left);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Right);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(0, 2, NavigationDirection.North);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction LMMR")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionLMMR()
        {
            roverCommands.Add(RoverCommand.Left);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Right);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(0, 2, NavigationDirection.North);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Rum Mars rover for the initial position 12N and commandinstruction RRMMMR")]
        [TestMethod]
        public void RunMarsRoverForInitialPosition12NAndCommandInstructionRRMMMR()
        {
            roverCommands.Add(RoverCommand.Right);
            roverCommands.Add(RoverCommand.Right);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Right);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(1, 0, NavigationDirection.West);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Validate that mars roves stop at the max co-ordinates of the plateu")]
        [TestMethod]
        public void ValidateMarsRoverStopsAtMaxCoOrinatesOfPlateu()
        {
            MarsPlateu marsPlateu = new MarsPlateu(3, 3);
            MarsRover marsRover = MarsRover.CreateRover(new MarsRoverPositionMock( 2, 2, NavigationDirection.North), marsPlateu);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Right);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(3, 3, NavigationDirection.East);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        [Description("Validate that mars roves stop at the mix co-ordinates of the plateu")]
        [TestMethod]
        public void ValidateMarsRoverStopsAtMinCoOrinatesOfPlateu()
        {
            MarsPlateu marsPlateu = new MarsPlateu(3, 3);
            MarsRover marsRover = MarsRover.CreateRover(new MarsRoverPositionMock( 2, 2, NavigationDirection.North), marsPlateu);
            roverCommands.Add(RoverCommand.Right);
            roverCommands.Add(RoverCommand.Right);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Right);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Move);
            roverCommands.Add(RoverCommand.Left);
            roverCommands.Add(RoverCommand.Left);
            marsRover.Run(roverCommands);
            var mock = new MarsRoverPositionMock(0, 0, NavigationDirection.East);
            Assert.IsTrue(marsRover.GetCurrentPostionAndDirection().Equals(mock));
        }

        private MarsRover GetDefaultRover()
        {
            MarsPlateu marsPlateu = new MarsPlateu(5, 5);
            MarsRover marsRover = MarsRover.CreateRover(new MarsRoverPositionMock( 1, 2, NavigationDirection.North), marsPlateu);
            return marsRover;
        }
    }
}
