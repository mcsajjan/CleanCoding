namespace MarsRovers.Functional.Tests
{
    using MarsRovers;
    using MarsRovers.CommandCenter;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RoverCommandCenterTest
    {
        MarsRoversCommandCenter marsRoverCommandCenter;

        [TestInitialize]
        public void InitializeTheVariables()
        {
            this.marsRoverCommandCenter = new MarsRoversCommandCenter();
            this.marsRoverCommandCenter.CreateMarsPlateu(new MarsPlateuSizeParser("5 5"));
        }

        [TestMethod]
        public void CanaryTest()
        {
            Assert.IsTrue(true);
        }

        [Description("Command center has single rover, execute the command")]
        [TestMethod]
        public void ExecuteCommandCenterHavingSingleRover()
        {
            this.marsRoverCommandCenter.NumberOfRovers = 1;
            this.marsRoverCommandCenter.AddMarsRoverInstructions(new MarsRoverInstructions
            { 
                RoverPosition = new MarsRoverParser("1 2 N")
                , CommandInstructions = RoverCommandUtility.GetRoverCommands("R")
                });
            Assert.AreEqual("1 2 E", MarsRoverParser.GetMarsRoverPositions(this.marsRoverCommandCenter.Execute()));
        }

        [Description("Command center has two rovers, execute the command")]
        [TestMethod]
        public void ExecuteCommandCenterHavingTwoRovers()
        {
            this.marsRoverCommandCenter.NumberOfRovers = 2;
            this.marsRoverCommandCenter.AddMarsRoverInstructions(new MarsRoverInstructions
            {
                RoverPosition = new MarsRoverParser("1 1 N")
                ,
                CommandInstructions = RoverCommandUtility.GetRoverCommands("R")
            });
            this.marsRoverCommandCenter.AddMarsRoverInstructions(new MarsRoverInstructions
            {
                RoverPosition = new MarsRoverParser("3 3 N")
                ,
                CommandInstructions = RoverCommandUtility.GetRoverCommands("R")
            });
            Assert.AreEqual("1 1 E" + System.Environment.NewLine + "3 3 E", MarsRoverParser.GetMarsRoverPositions(this.marsRoverCommandCenter.Execute()));
        }

        [Description("Command center has two rovers, rover positions overlap")]
        [TestMethod]
        public void ExecuteCommandCenterHavingTwoRoversPositionOverLapping()
        {
            this.marsRoverCommandCenter.NumberOfRovers = 2;
            this.marsRoverCommandCenter.AddMarsRoverInstructions(new MarsRoverInstructions
            {
                RoverPosition = new MarsRoverParser("1 1 N")
                ,
                CommandInstructions = RoverCommandUtility.GetRoverCommands("MMRMM")
            });
            this.marsRoverCommandCenter.AddMarsRoverInstructions(new MarsRoverInstructions
            {
                RoverPosition = new MarsRoverParser("3 3 N")
                ,
                CommandInstructions = RoverCommandUtility.GetRoverCommands("R")
            });
            //We will not move the rover if poistion is overlapping
            Assert.AreEqual("1 1 N" + System.Environment.NewLine + "3 3 E", MarsRoverParser.GetMarsRoverPositions(this.marsRoverCommandCenter.Execute()));
        }
    }
}
