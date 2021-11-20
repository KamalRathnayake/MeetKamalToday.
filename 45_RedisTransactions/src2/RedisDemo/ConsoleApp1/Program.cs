using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
		{// assign a new unique id only if they don't already
		 // have one, in a transaction to ensure no thread-races
			var newId = CreateNewUniqueID(); // optimistic
			using (var tran = conn.BeginTran())
			{
				var cust = GetCustomer(conn, custId, tran);
				var uniqueId = cust.UniqueID;
				if (uniqueId == null)
				{
					cust.UniqueId = newId;
					SaveCustomer(conn, cust, tran);
				}
				tran.Complete();
			}
		}
    }
}
