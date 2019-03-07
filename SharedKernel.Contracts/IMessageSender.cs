
namespace Kryptand.ChefMaster.Core.SharedKernel.Contracts
{
	public interface IMessageSender
    {
        void sendMessage(string toAddress, string messageBody);
    }
}
