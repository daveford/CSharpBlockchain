
using System.Collections.Generic;

namespace CSharpBlockchain.Models
{
    public class Block
    {
        public int Index {get; set;}
        public long timestamp {get; set;}
        public List<Transaction> Transactions {get; set;}
        public long Proof {get; set;}
        public string PreviousHash {get; set;}
    }
}