using ChinaSweeper.Base;
using ChinaSweeper.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChinaSweeper.MineSweeperPage
{
    public class MineSweeperPageViewModel : BaseViewModel
    {
        Board board;
        public MineSweeperPageViewModel(Board board)
        {
            Title = Titles.MineSweeperPageViewTitle;

            this.board = board;
        }


        /* public int MineCount
        {
            get
            {
                return board.MineCount;
            }
            set 
            {
                
            }
        }

        public int FlaggedTileCount
        {
            get
            {
                return board.FlaggedTileCount;
            }
            set
            {

            }
        } */
    }
}
