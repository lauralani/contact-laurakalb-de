using System.Collections.Generic;

namespace contact
{
    public class Email
    {
        public List<string> To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string ReplyTo { get; set; }
        public string PlainBody { get; set; }
    }
}
