namespace FlatManagement.Common.Validation
{
	public class HashCode
	{
		public static int Compute(object o)
		{
			if (o == null)
			{
				return 0;
			}
			else
			{
				return o.GetHashCode();
			}
		}

		public static int Compute(params object[] args)
		{
			unchecked
			{
				int hash = 17;

				foreach (object item in args)
				{
					hash = hash * 23 + Compute(item);
				}

				return hash;
			}
		}
	}
}
