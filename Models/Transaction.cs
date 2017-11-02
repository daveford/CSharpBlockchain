using System;

namespace CSharpBlockchain.Models
{
    [Serializable()]
    public class Transaction
    {
        public string Sender {get; set;}
        public string Recipient {get; set;}
        public int Amount {get; set;}
    }
}