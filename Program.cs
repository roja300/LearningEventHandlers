using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static LearningEventHandlers.Program;

namespace LearningEventHandlers
{
    internal class Program
    {
        public static char inputLetter;
        static void Main(string[] args)
        {
            Console.WriteLine("Press Key");

            Thread listenForKeyThread = new Thread(ListenForKey); //thread to listen for key (not needed but want anyway)
            listenForKeyThread.Start(); //start thread
        }

        static void ListenForKey()
        {
            while (true) //loop so that it is always listening
            {
                inputLetter = Console.ReadKey().KeyChar;

                KeyPressed();
            }
        }

        static void KeyPressed()
        {
            Key key = new Key(); //call key object
            key.KeyPressEvent += (s, args) => //what to do during event
            {
                Console.WriteLine("\n'{0}' key pressed", inputLetter); //prints key pressed
            };
            key.OnKeyPress(); //invoke key press
        }
   
    }
    public class Key
    {
        public EventHandler KeyPressEvent;
        public void OnKeyPress()
        {
            KeyPressEvent.Invoke(this, EventArgs.Empty);
        }
    }
}

//how to use
//add event handler to class
//add event to class
//create an invoke function 'Invoke(source, arguments)'
//listen for event
//invoke event using event handler
//do function