﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Spelprojekt.Services
{
    public class GameService
    {

        public int UpdateYPosition(int currentY)
        {
            return currentY + 1;
        }

        public void OnGameUpdated(object source, EventArgs e)
        {
            //var message = "Gameservice";
            //MessageBox.Show(message);

        }





    }
}
