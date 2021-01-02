using JollyPoker.Core.Hand;

namespace JollyPoker.Services
{
	public class HandResult
	{
		public HandResult(IHand result)
		{
			Result = result;
		}

		public IHand Result { get; set; }
	}
}