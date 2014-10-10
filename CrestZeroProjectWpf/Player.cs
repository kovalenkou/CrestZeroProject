using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrestZeroProjectWpf
{
    class Player
    {
        int[,] arrWin = new int[8, 4] { { 0, 1, 2, 0 }, { 3, 4, 5, 0 }, { 6, 7, 8, 0 }, { 0, 4, 8, 0 },
                                { 2, 4, 6, 0 }, { 0, 3, 6, 0 }, { 1, 4, 7, 0 }, { 2, 5, 8, 0 }};
        string name;
        string chooseXO;

        public Player(string name, string chXO)
        {
            this.name = name;
            this.chooseXO = chXO;
        }

        public string Name { get { return this.name; } }
        public string ChooseXO { get { return this.chooseXO; } }

        public void Move()
        {
            ;
        }
    }
}
