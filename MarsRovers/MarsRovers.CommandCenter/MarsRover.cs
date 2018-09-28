namespace MarsRovers.CommandCenter
{
    using MarsRovers.CommandCenter;
    using System.Collections.Generic;

    public class MarsRover : MarsRoverPosition
    {
        private MarsPlateu MarsPlateu { get; set; }
        private int PreviousPositionXCoOridante { get; set; }
        private int PreviousPositionYCoOrdinate { get; set; }
        private NavigationDirection PrevioustDirectionOfRover { get; set; }

        public static MarsRover CreateRover(MarsRoverPosition roverPostion, MarsPlateu marsPlateu)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.MarsPlateu = marsPlateu;
            marsRover.CurrentPositionXCoOridante = roverPostion.CurrentPositionXCoOridante;
            marsRover.CurrentPositionYCoOrdinate = roverPostion.CurrentPositionYCoOrdinate;
            marsRover.CurrentDirectionOfRover = roverPostion.CurrentDirectionOfRover;
            marsRover.PreviousPositionXCoOridante = marsRover.CurrentPositionXCoOridante;
            marsRover.PreviousPositionYCoOrdinate = marsRover.CurrentPositionYCoOrdinate;
            marsRover.PrevioustDirectionOfRover = marsRover.CurrentDirectionOfRover;
            return marsRover;
        }

        public int CurrentPositionXCoOridante { get; set; }
        public int CurrentPositionYCoOrdinate { get; set; }
        public NavigationDirection CurrentDirectionOfRover { get; set; }
        public IList<RoverCommand> InitialCommandInstructions { get; set; }

        public void Run(IList<RoverCommand> commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case RoverCommand.Left:
                        this.TurnLeft();
                        break;
                    case RoverCommand.Right:
                        this.TurnRight();
                        break;
                    case RoverCommand.Move:
                        this.MoveRover();
                        break;
                }
            }

            if (!this.MarsPlateu.MarsRovers.ContainsKey(this.CurrentPostionToString()))
            {
                this.MarsPlateu.MarsRovers.Add(this.CurrentPostionToString(), this);
                this.MarsPlateu.MarsRovers.Remove(this.CurrentPostionToString());
            }
            else
            {
                MarsRover existingMarsRoverInPlateu = this.MarsPlateu.MarsRovers[this.CurrentPostionToString()];

                if (existingMarsRoverInPlateu.PreviousPostionAndDirectionToString() != this.PreviousPostionAndDirectionToString())
                {
                    this.CurrentPositionXCoOridante = this.PreviousPositionXCoOridante;
                    this.CurrentPositionYCoOrdinate = this.PreviousPositionYCoOrdinate;
                    this.CurrentDirectionOfRover = this.PrevioustDirectionOfRover;
                }
            }
        }

        private void MoveRover()
        {
            switch (this.CurrentDirectionOfRover)
            {
                case NavigationDirection.East:
                    if (this.CurrentPositionXCoOridante < this.MarsPlateu.XcoOdinate)
                    {
                        this.CurrentPositionXCoOridante++;
                    }
                    break;
                case NavigationDirection.West:
                    if (this.CurrentPositionXCoOridante > 0)
                    {
                        this.CurrentPositionXCoOridante--;
                    }
                    break;
                case NavigationDirection.North:
                    if (this.CurrentPositionYCoOrdinate < this.MarsPlateu.YcoOrdinate)
                    {
                        this.CurrentPositionYCoOrdinate++;
                    }
                    break;
                case NavigationDirection.South:
                    if (this.CurrentPositionYCoOrdinate > 0)
                    {
                        this.CurrentPositionYCoOrdinate--;
                    }
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.CurrentDirectionOfRover)
            {
                case NavigationDirection.East:
                    this.CurrentDirectionOfRover = NavigationDirection.South;
                    break;
                case NavigationDirection.West:
                    this.CurrentDirectionOfRover = NavigationDirection.North;
                    break;
                case NavigationDirection.North:
                    this.CurrentDirectionOfRover = NavigationDirection.East;
                    break;
                case NavigationDirection.South:
                    this.CurrentDirectionOfRover = NavigationDirection.West;
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (this.CurrentDirectionOfRover)
            {
                case NavigationDirection.East:
                    this.CurrentDirectionOfRover = NavigationDirection.North;
                    break;
                case NavigationDirection.West:
                    this.CurrentDirectionOfRover = NavigationDirection.South;
                    break;
                case NavigationDirection.North:
                    this.CurrentDirectionOfRover = NavigationDirection.West;
                    break;
                case NavigationDirection.South:
                    this.CurrentDirectionOfRover = NavigationDirection.East;
                    break;
            }
        }

        public MarsRoverPosition GetCurrentPostionAndDirection()
        {
            return this as MarsRoverPosition;
        }

        public override bool Equals(object obj)
        {
            bool isMarsRoverPositionEquals = false;
            if (obj is MarsRoverPosition)
            {
                MarsRoverPosition roverPosition = obj as MarsRoverPosition;
                if (this.CurrentPositionXCoOridante == roverPosition.CurrentPositionXCoOridante
                    && this.CurrentPositionYCoOrdinate == roverPosition.CurrentPositionYCoOrdinate
                    && this.CurrentDirectionOfRover == roverPosition.CurrentDirectionOfRover)
                {
                    isMarsRoverPositionEquals = true;
                }
            }

            return isMarsRoverPositionEquals;
        }

        public string PreviousPostionAndDirectionToString()
        {
            return this.PreviousPositionXCoOridante.ToString() + " " + this.PreviousPositionYCoOrdinate.ToString() + " " + this.PrevioustDirectionOfRover.ToString();
        }

        public string CurrentPostionToString()
        {
            return this.CurrentPositionXCoOridante.ToString() + " " + this.CurrentPositionYCoOrdinate.ToString();
        }
    }
}
