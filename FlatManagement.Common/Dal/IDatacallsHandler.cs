using System.Collections;

namespace FlatManagement.Common.Dal
{
	public interface IDatacallsHandler
	{
		IEnumerable GetMany(string command, Parameter[] parameters, IDataReaderRowConverter converter);
		bool GetBool(string command, Parameter[] parameters);
		object GetOne(string command, Parameter[] parameters, IDataReaderRowConverter converter, bool throwIfMultipleResultFound = false);
		int Execute(string command, Parameter[] parameters, Parameter[] outParameters);
		int Execute(string command, Parameter[] parameters);
	}
}