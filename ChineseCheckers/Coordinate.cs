using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public class Coordinate : IEquatable<Coordinate>
    {
        private int _i;
        private int _j;

        public int i { 
            get { return _i; }
            set { _i = value; }
        }

        public int j
        {
            get { return _j; }
            set { _j = value; }
        }

        public Coordinate(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Coordinate other = obj as Coordinate;
            if (other == null) return false;
            return (this.i == other.i && this.j == other.j);
        }

        public override int GetHashCode()
        {
            int code = 1000000;
            code = code + (i * 1000);
            code = code + j;
            return code;
        }

        public bool Equals(Coordinate other)
        {
            if (other == null) return false;
            return (this.i == other.i && this.j == other.j);
        }
    }
}
