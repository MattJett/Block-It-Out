/**
 * Name: Matthew Jett
 * Class: CSCD 371-01 .Net Programming with C# with Tom Capaul Spring 2018
 * Description: This is an incomplete class, not currently used in my program right now due to it being commented out.
 *              But, I was trying to make a new Event that would use the Block that called it and check to see if the block was intersected with the ball.
 */

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Block_It_Out
{
    public class CollisionArgs : EventArgs
    {
        private Rect _r1;
        private Rect _r2;

        public CollisionArgs(Rect r1, Rect r2)
        {
            _r1 = r1;
            _r2 = r2;
        }

        public bool CheckCollision()
        {
            return _r1.IntersectsWith(_r2);
        }
    }
}