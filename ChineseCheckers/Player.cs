using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public class Player
    {
        private int _Id;
        private string _Name;
        private List<Coordinate> _StartCoordinates;
        private List<Coordinate> _GoalCoordinates;

        public int Id
        {
            get { return _Id; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public List<Coordinate> StartCoordinates
        {
            get { return _StartCoordinates; }
            set 
            {
                if (_StartCoordinates == null)
                    _StartCoordinates = value;
                else
                    throw new InvalidOperationException("StartCoordinates can only be set one time");
            }
        }
        public List<Coordinate> GoalCoordinates
        {
            get { return _GoalCoordinates; }
            set
            {
                if (_GoalCoordinates == null)
                    _GoalCoordinates = value;
                else
                    throw new InvalidOperationException("GoalCoordinates can only be set one time");
            }
        }

        public Player(int id)
        {
            _Id = id;
        }

        public bool IsPlayerCoordinate(int i, int j)
        {
            foreach (Coordinate c in StartCoordinates)
                if (c.i == i && c.j == j)
                    return true;
            foreach (Coordinate c in GoalCoordinates)
                if (c.i == i && c.j == j)
                    return true;
            return false;
        }
    }
}
