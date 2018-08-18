/**
 * Name: Matthew Jett
 * Class: CSCD 371-01 .Net Programming with C# with Tom Capaul Spring 2018
 * Description: This simple class is the data that is bound to the Rectangle template in the xaml code's ItemsControl.ItemsTemplate
 *              Contains a simple boolean that will help a trigger to enable visability or disable visablity of the corresponding block.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Block_It_Out
{
    public class Block
    {
        #region Properties
        public bool BlockState { get; set; }
        #endregion

        #region Constructor
        public Block(bool state)
        {
            BlockState = state;
        }
        #endregion

        //public delegate void CollisionEventHandler(object o, CollisionArgs e);
        //public event CollisionEventHandler OnCollisionEvent;

        //public bool something()
        //{
        //    if ()
        //}
    }
}
