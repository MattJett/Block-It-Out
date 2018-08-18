/**
 * Name: Matthew Jett
 * Class: CSCD 371-01 .Net Programming with C# with Tom Capaul Spring 2018
 * Description: This Paddle class contains all the data needed for the paddle. Methods for removing paddle from screen when game is paused,
 *              making a new paddle, and resume it's position on the Canvas after gameplay is resumed.
 */

using System.Windows;
using System.Windows.Controls;

namespace Block_It_Out
{
    public class Paddle : UIElement
    {
        #region Field
        private readonly MainWindow _window;
        #endregion

        #region Properties
        public int PaddleDx { get; set; }
        public double PaddleTop { get; set; }
        public double PaddleLeft { get; set; }
        public double PaddleBottom { get; set; }
        public double PaddleRight { get; set; }
        #endregion

        #region Constructor
        public Paddle(int dx, double top, double left, MainWindow window)
        {
            _window = window;
            PaddleDx = dx;
            PaddleTop = top;
            PaddleLeft = left;
            PaddleBottom = top + _window.Rectangle_Paddle.Height;
            PaddleRight = left + _window.Rectangle_Paddle.Width;
        }
        #endregion

        #region Methods
        public void NewPaddle()
        {
            PaddleTop = Canvas.GetTop(_window.Rectangle_Paddle);
            PaddleLeft = Canvas.GetLeft(_window.Rectangle_Paddle);
            PaddleDx = 10;
        }

        public void KillPaddle()
        {
            _window.Rectangle_Paddle.IsEnabled = false;
            _window.Rectangle_Paddle.Opacity = 0;
        }

        public void ResumePaddle()
        {
            _window.Rectangle_Paddle.IsEnabled = true;
            _window.Rectangle_Paddle.Opacity = 1;
        } 
        #endregion
    }
}
