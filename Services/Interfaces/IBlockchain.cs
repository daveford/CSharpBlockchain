using CSharpBlockchain.Models;

namespace CSharpBlockchain.Services.Interfaces
{
    public interface IBlockchain
    {
        int NewTransaction(string sender, string recipient, int amount);
        Block NewBlock(int proof, string prevHash = "");
        Block LastBlock();
    }
}