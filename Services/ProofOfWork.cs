using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using CSharpBlockchain.Services.Interfaces;

namespace CSharpBlockchain.Services
{
    public class ProofOfWork : IProofOFWork
    {
        public int RunProofOfWork(int lastProof)
        {
            int proof = 0;
            while(!ValidProof(lastProof, proof)) proof++;
            return proof;
        }

        private bool ValidProof(int lastProof, int proof)
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}{1}", lastProof, proof);
            BinaryFormatter bf = new BinaryFormatter();
            byte[] arr, guessHash;
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, str.ToString());
                arr = ms.ToArray();
            }
            using (SHA256 hash = SHA256Managed.Create()) {
               guessHash = hash.ComputeHash(arr);
            }
            string lastFour = String.Empty;
            for(int i=guessHash.Length-5; i<guessHash.Length; i++)
            {
                lastFour += guessHash[i];
            }
            return lastFour == "0000";
        }
    }
}