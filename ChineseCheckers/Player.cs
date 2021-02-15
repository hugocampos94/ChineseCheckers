using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public class Player
    {
        private int id;
        private int number;
        private string name;
        private bool active;
        private readonly List<Coordinate> startCoordinates;
        private readonly List<Coordinate> goalCoordinates;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public List<Coordinate> StartCoordinates
        {
            get { return StartCoordinates; }
            set { StartCoordinates = value; }
        }
        public List<Coordinate> GoalCoordinates
        {
            get { return GoalCoordinates; }
            set { GoalCoordinates = value; }
        }

        public Player(int id, List<Coordinate> startCoordinates, List<Coordinate> goalCoordinates)
        {
            this.id = id;
            this.startCoordinates = startCoordinates;
            this.goalCoordinates = goalCoordinates;
        }
    }
}
