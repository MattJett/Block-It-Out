/**
 * Name: Matthew Jett
 * Class: CSCD 371-01 .Net Programming with C# with Tom Capaul Spring 2018
 * Description: This Ball class contains all the data of the ball. A few methods allow this ball to be reset to default starting position,
 *              remove it from the screen, and create a new one.
 */

using System;
using System.Windows;
using System.Windows.Controls;

namespace Block_It_Out
{
    public class Ball : UIElement
    {
        #region Field
        private readonly MainWindow _window;
        #endregion

        #region Properties
        public int BallDx { get; set; }
        public int BallDy { get; set; }
        public double BallTop { get; set; }
        public double BallLeft { get; set; }
        public double BallBottom { get => BallTop + _window.Rectangle_Ball.Height; }
        public double BallRight { get => BallLeft + _window.Rectangle_Ball.Width; }

        #endregion

        #region Constructor
        public Ball(int dx, int dy, double top, double left, MainWindow window)
        {
            _window = window;
            BallDx = dx;
            BallDy = dy;
            BallTop = top;
            BallLeft = left;
        }
        #endregion

        #region Methods
        public void ResetBall()
        {
            NewBall(_window.Rectangle_Ball.Width, _window.Rectangle_Ball.Height, new Random().Next(82, 643), 750);
            _window.Rectangle_Paddle.Width = 180;
            _window.RotateTransform_Paddle.Angle = 0;
            BallLeft = Canvas.GetLeft(_window.Rectangle_Ball);
            BallTop = Canvas.GetTop(_window.Rectangle_Ball);
            BallDx = -3;
            BallDy = -3;
            ResumeBall();
        }

        public void NewBall(double width, double height, int onX, int onY)
        {
            Canvas.SetLeft(_window.Rectangle_Ball, onX);
            Canvas.SetTop(_window.Rectangle_Ball, onY);
        }

        public void KillBall()
        {
            _window.Rectangle_Ball.IsEnabled = false;
            _window.Rectangle_Ball.Opacity = 0;
            _window.Timer.Stop(); // PAUSE GAME
        }

        public void ResumeBall()
        {
            _window.Rectangle_Ball.IsEnabled = true;
            _window.Rectangle_Ball.Opacity = 1;
            _window.Timer.Start(); // RESUME GAME
        } 
        #endregion
    }
}
