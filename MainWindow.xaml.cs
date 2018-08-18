/**
 * Name: Matthew Jett
 * Class: CSCD 371-01 .Net Programming with C# with Tom Capaul Spring 2018
 * Description: This serves as the controller for my program, bridging the view of the xaml code to the backend C# code of the other files.
 *              MainWindow contains all events, inputs, score, and timer properties.
 * Notes for Grader: I tried my heart out on this project, I couldn't figure out an effiecient way to detect collisions on the blocks.
 *                   My issue is easy to see, I just don't have enough time to figure this out. I've asked Tom for help and he had no idea
 *                   how to solve it either, I've asked on Stack Overflow and no luck there, along with days of research and trying many
 *                   different techniques. Simply, in my ItemsControl in the XAML code of MainWindow, I have an ItemsPanel generated through
 *                   the ItemsControl as a UniformGrid and I'm binding a list of Block class items into a DataTemplate of Rectangle UIElement.
 *                   The problem is that I can't figure out a way to ask in code, "give me not my Block, but rather the element it's binded to
 *                   or the Rectangle UIElement to access it's properties such as it's position in the grid, it's location, etc. You might see
 *                   commented out code in Block class and the MainWindow class, this commented out code was my sad sad attempt to create a custom
 *                   event handler and delegate to give each Block it's own sense of awareness to report back when it was collided with, allowing
 *                   easier detection to find which block was hit by the ball. I'm confident I will be able to figure this out, but once again,
 *                   I'm out of time. So, I'll write int he next section below what I did implement and what I didn't in my submission.
 * ACCOMPLISHED: Generated all elements on screen, added textures, binded mouse input to paddle, correctly animating per DispatcherTimer tick,
 *               paddle tilting, correctly binding objects to a template using WPF and auto generating all block systematically. Finished layout
 *               and adding a start/pause and exit button with functionality, a high score and progressivily updating score box.
 * INCOMPLETED: I was never able to correctly implement collision detection on my Blocks, prob would have been easier in Unity,
 *              WFP sucks for games is something I've taken away from this...
 *              Lastly, I couldn't get around to appling the Lights Out game algorithm behavior to the Blocks when collided with.
 *              And Sound effects, but that part I just didn't get around too, because of time, it would have been completely doable for me.
 * TAKE AWAY and WHY SHOULD I STILL DESERVE A DECENT GRADE: Given I never got a chnace to completely implement this game in it's entirety, I still
 *                                                          learned a lot. I've demonstated in this assignment and past assignments that I know how
 *                                                          to create custom styling and resource code inside the app.xaml and resources files and
 *                                                          using these to override and create new looks and behaviors to my WPF program. I've shown
 *                                                          that I know how to work with events and user input controls such as the mouse and keyboard
 *                        ^                                 to control elements on the screen. I've shown how to bind backend objects to elements created
 *                        |                                 in custom templates and panels generated systematically in WPF, reducing the amount of code in
 *                  FOR THE GRADER                          C# and correctly using WPF for what it was designed for, instead of using it through C# code like
 *                                                          WinForms. I've shown how to add textures to elements and animate elements through a timer.
 *                                                          I've also shown a sense of design for the UI by lining things up right, placing the menu and adding
 *                                                          buttons to control the game, and correctly updating a score each time the ball hits the paddle.
 *                                                          Bottom line is, I feel I should deserve a B or a low B at least for my efforts and for what I've
 *                                                          implemented. I currently have a 108% in the class and I've tried to get done what I could, but
 *                                                          my grade and efforts should say that I would have had the potential to get this done successfully.
 */

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Block_It_Out
{
    /// <inheritdoc cref="Window" />
    /// <summary>
    /// Interaction logic for MainWindow.xaml and DispatcherTimer code
    /// </summary>
    public partial class MainWindow
    {
        #region Fields
        private int _score;
        private int _highScore; 
        #endregion

        #region Properties
        public DispatcherTimer Timer { get; }
        public Ball Ball { get; }
        public Paddle Paddle { get; }
        public List<Block> Blocks { get; private set; }
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            Paddle = new Paddle(10, Canvas.GetTop(Rectangle_Paddle), Canvas.GetLeft(Rectangle_Paddle), this);
            Ball = new Ball(3, -3, Canvas.GetTop(Rectangle_Ball), Canvas.GetLeft(Rectangle_Ball), this);
            BindBlocks();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 15);
            Timer.Tick += Timer_Tick;

            Paddle.KillPaddle();
            Ball.KillBall();
        } 
        #endregion

        #region Inputs
        // TILT PADDLE
        private void Window_KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    if (RotateTransform_Paddle.Angle > -60)
                        RotateTransform_Paddle.Angle += -10;
                    else
                        RotateTransform_Paddle.Angle = -60;
                    break;
                case Key.D:
                    if (RotateTransform_Paddle.Angle < 60)
                        RotateTransform_Paddle.Angle += 10;
                    else
                        RotateTransform_Paddle.Angle = 60;
                    break;
                case Key.W:
                    RotateTransform_Paddle.Angle = 0;
                    break;
                case Key.S:
                    RotateTransform_Paddle.Angle = 0;
                    break;
            }
        }

        // MOVE PADDLE
        private void Canvas_TrackPaddleEvent(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(Canvas_GameBoard);
            double pX = position.X;

            if ((Paddle.PaddleLeft = pX) <= 0)
            {
                Canvas.SetLeft(Rectangle_Paddle, 0);
            }
            else if ((Paddle.PaddleLeft = pX + Rectangle_Paddle.Width) >= Canvas_GameBoard.Width)
            {
                Canvas.SetLeft(Rectangle_Paddle, Canvas_GameBoard.Width - Rectangle_Paddle.Width);
            }
            else
            {
                Canvas.SetLeft(Rectangle_Paddle, pX);
            }
            Paddle.PaddleLeft = Canvas.GetLeft(Rectangle_Paddle);
            Paddle.PaddleRight = Paddle.PaddleLeft + Rectangle_Paddle.Width;
        }
        #endregion

        #region Private Methods
        private void BindBlocks()
        {
            Blocks = new List<Block>();
            for (var c = 0; c < 8; c++)
            {
                for (var r = 0; r < 4; r++)
                {
                    Blocks.Add(new Block(true));
                }
            }
            ItemsControl_BlockBinding.ItemsSource = Blocks;
            //OnCollisionEvent();
        }

        private void ScoreReset()
        {
            if (_score > _highScore)
            {
                MessageBox.Show("You lost. But, look at that high _score!", "GAME OVER", MessageBoxButton.OK);
                _highScore = _score;
                TextBox_HighScore.Text = _highScore.ToString();
                _score = 0;
                TextBox_ScoreBoard.Text = _score.ToString();
            }
            else
            {
                MessageBox.Show("You suck at this. Press OK if you agree.", "GAME OVER", MessageBoxButton.OK);
                _score = 0;
            }
        } 
        #endregion

        #region Events
        private void Timer_Tick(object sender, EventArgs e)
        {
            //TODO: put on seperate thread to prevent crashing at late game...

            if (Ball.BallTop <= Paddle.PaddleBottom)
            {
                if (Ball.BallLeft < 0 || Ball.BallRight > Canvas_GameBoard.Width)
                    Ball.BallDx *= -1;
                if (Ball.BallTop < 0)
                    Ball.BallDy *= -1;

                if (Ball.BallBottom >= Paddle.PaddleTop)
                {
                    if (Ball.BallLeft >= Paddle.PaddleLeft)
                    {
                        if (Ball.BallLeft <= Paddle.PaddleRight)
                        {
                            Ball.BallDy *= -1;
                            _score++;
                            TextBox_ScoreBoard.Text = _score.ToString();
                        }
                    }
                    else if (Ball.BallRight >= Paddle.PaddleLeft)
                    {
                        if (Ball.BallRight <= Paddle.PaddleRight)
                        {
                            Ball.BallDy *= -1;
                            _score++;
                            TextBox_ScoreBoard.Text = _score.ToString();
                        }
                    }
                }
            }
            else
            {
                Ball.KillBall();
                ScoreReset();
                Ball.ResetBall();
            }

            Canvas.SetLeft(Rectangle_Ball, Ball.BallLeft += Ball.BallDx);
            Canvas.SetTop(Rectangle_Ball, Ball.BallTop += Ball.BallDy);
        }

        //private void OnCollisionEvent()
        //{
            
        //    foreach (Block item in ItemsControl_BlockBinding.Items)
        //    {
                
        //        var container = ItemsControl_BlockBinding.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
        //        var block = ItemsControl_BlockBinding.ItemTemplate.FindName("Rectangle_Block", container) as Rectangle;

        //        MessageBox.Show(block.GetType().ToString());
        //    }
            
        //}

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            if (Button_Start.Content.ToString() == "START")
            {
                Ball.ResetBall();
                Paddle.NewPaddle();
                Paddle.ResumePaddle();
                Button_Start.Content = "PAUSE";
                Button_Start.Background = new SolidColorBrush(Color.FromRgb(219, 220, 195));
                Button_Start.Foreground = new SolidColorBrush(Color.FromRgb(187, 154, 40));
            }
            else
            {
                if (Timer.IsEnabled)
                {
                    Ball.KillBall();
                    Paddle.KillPaddle();
                }
                else
                {
                    Paddle.ResumePaddle();
                    Ball.ResumeBall();
                }
            }
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
    }
}
