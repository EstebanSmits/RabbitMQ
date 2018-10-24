using System;
using EasyNetQ;
using Messages;

namespace subscriber1
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
               var subscriptionResult= bus.Subscribe<TextMessage>("", HandleTextMessage);
            
                bool _quitFlag =false;
                Console.WriteLine("Listening for messages.Ctrl+C to exit");
                while(!_quitFlag)
                {
                    var keyInfo = Console.ReadKey();
                    _quitFlag = keyInfo.Key == ConsoleKey.C && keyInfo.Modifiers == ConsoleModifiers.Control;
                }
            }
            


        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.WriteLine("Got message: {0}", textMessage.Text);
        }
    }
}
