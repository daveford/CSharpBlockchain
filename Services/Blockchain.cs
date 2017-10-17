using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using CSharpBlockchain.Models;
using CSharpBlockchain.Services.Interfaces;

namespace CSharpBlockchain.Services
{
    public class Blockchain : IBlockchain
    {
        private List<Block> _Chain;
        public int NewTransaction(string sender, string recipient, int amount)
        {
            throw new System.NotImplementedException();
        }

        public Block NewBlock(int proof, string prevHash)
        {
            throw new System.NotImplementedException();
        }

        public Block LastBlock()
        {
            return _Chain[_Chain.Count - 2];
        }

        private byte[] GetHash(Block block)
        {
            throw new NotImplementedException();
        }
    }
}