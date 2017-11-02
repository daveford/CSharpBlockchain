using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using CSharpBlockchain.Models;
using CSharpBlockchain.Services.Interfaces;

namespace CSharpBlockchain.Services
{
    public class Blockchain : IBlockchain
    {
        private List<Block> _Chain;
        private List<Transaction> _CurrentTransactions;
        public int NewTransaction(string sender, string recipient, int amount)
        {
            _CurrentTransactions.Add(new Transaction{
                Sender = sender,
                Recipient = recipient,
                Amount = amount
            });
            
            return _Chain.Count;
        }

        public Block NewBlock(int proof, string prevHash="")
        {
            _Chain.Add(new Block{
                Index = 0,
                Timestamp = DateTime.Now.Ticks,
                Transactions = _CurrentTransactions,
                Proof = proof,
                PreviousHash = prevHash
            });

            _CurrentTransactions.Clear();
            return _Chain[_Chain.Count-1];
        }

        public Block LastBlock()
        {
            return _Chain[_Chain.Count - 2];
        }

        private byte[] GetHash(Block block)
        {
            if(block == null)
                return null;
            
            BinaryFormatter bf = new BinaryFormatter();
            byte[] arr, blockHash;
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, block);
                arr = ms.ToArray();
            }
            using (SHA256 hash = SHA256Managed.Create()) {
               blockHash = hash.ComputeHash(arr);
            }
            return blockHash;
        }
    }
}