using System;
using System.Transactions;

namespace FlatManagement.Common.Transaction
{
	public class TransactionUtil
	{
		public static TransactionScope New()
		{
			TransactionOptions transactionOptions = new TransactionOptions()
			{
				IsolationLevel = IsolationLevel.ReadCommitted,
				Timeout = TransactionManager.MaximumTimeout
			};
			return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
		}
	}
}
