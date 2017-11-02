
using System;
using System.Collections.Generic;

namespace CSharpBlockchain.Models
{
    [Serializable()]
    public class Block
    {
        public int Index {get; set;}
        public long Timestamp {get; set;}
        public List<Transaction> Transactions {get; set;}
        public long Proof {get; set;}
        public string PreviousHash {get; set;}
    }
}