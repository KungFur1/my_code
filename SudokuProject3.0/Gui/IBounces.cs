using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject3._0.Gui
{
    interface IBounces
    {
        void CheckRightWall();
        void CheckLeftWall();
        void CheckTopWall();
        void CheckBottomWall();
    }
}
