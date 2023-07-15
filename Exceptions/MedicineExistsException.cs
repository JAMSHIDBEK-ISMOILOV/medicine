using System;
namespace Medicine.WebApi.Exceptions
{
	public class MedicineExistsException : Exception
	{
		private const string _message = "Medicine exists!";

		public MedicineExistsException() : base(_message) { }
	}
}

