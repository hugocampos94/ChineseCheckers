using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public class Coordinate : IEquatable<Coordinate>
    {
        private double _i;
        private double _j;
        private static int numDecimals = 3;

        public double i
        { 
            get { return _i; }
            set { _i = Math.Round(value, numDecimals); }
        }

        public double j
        {
            get { return _j; }
            set { _j = Math.Round(value, numDecimals); }
        }

        public int iInt
        {
            get { return (int)Math.Round(_i); }
        }

        public int jInt
        {
            get { return (int)Math.Round(_j); }
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

        //public override int GetHashCode()
        //{
        //    int code = 1000000;
        //    code = code + (i * 1000);
        //    code = code + j;
        //    return code;
        //}

        public bool Equals(Coordinate other)
        {
            if (other == null) return false;
            return (this.i == other.i && this.j == other.j);
        }

        public override int GetHashCode()
        {
            int hashCode = 1654729226;
            hashCode = hashCode * -1521134295 + _i.GetHashCode();
            hashCode = hashCode * -1521134295 + _j.GetHashCode();
            hashCode = hashCode * -1521134295 + i.GetHashCode();
            hashCode = hashCode * -1521134295 + j.GetHashCode();
            return hashCode;
        }
    }
}
