using System;

namespace Classifieds.Domain.Utils
{
    public class Message
    {
        public String Data { get; set; }

        public Boolean Valid { get; set; }

        public Exception InternalException { get; set; }

        public Message()
        {
            Valid = true;
            InternalException = null;
            Data = "";
        }

        public Message(Boolean valid, string data = "")
        {
            Valid = valid;
            Data = data;
            InternalException = null;
        }

        public Message(Exception internalException, string data = "")
        {
            Valid = false;
            Data = data;
            InternalException = internalException;
        }
    }
}