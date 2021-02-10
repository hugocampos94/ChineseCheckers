using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Test
{
    [TestFixture]
    public class BoardShould
    {
        [Test]
        public void ValidateCorrectPlayer()
        {
            var board = new Board(2);
            Assert.IsTrue(board.IsPlayer(0, 6));
            Assert.IsTrue(board.IsPlayer(13, 4));
            Assert.IsFalse(board.IsPlayer(0, 0));
            Assert.IsFalse(board.IsPlayer(4, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => { board.IsPlayer(-23, -1000); });
            Assert.Throws<ArgumentOutOfRangeException>(() => { board.IsPlayer(20000, 100000); });
        }


    }
}
