using System;
namespace Medicine.WebApi.Exceptions
{
	public class MedicineNotFoundException : Exception
	{
		private const string _message = "Medicine not found!";

		public MedicineNotFoundException() : base(_message) { }
	}
}

