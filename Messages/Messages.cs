using EasyNetQ;
namespace Messages
{
    [Queue("TestMessagesQueue", ExchangeName = "TestMessageExchange")]
    public class TextMessage
    {
        public string Text { get; set; } 
    }
}