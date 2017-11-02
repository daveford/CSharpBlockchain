namespace CSharpBlockchain.Services.Interfaces
{
    public interface IProofOFWork
    {
        int RunProofOfWork(int lastProof);
    } 
}