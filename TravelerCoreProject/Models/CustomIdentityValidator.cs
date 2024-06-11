using Microsoft.AspNetCore.Identity;

namespace TravelerCoreProject.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		//min 6 karakter
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola minumum {length} karakter olmalıdır."
			};
		}
		//En az 1 büyük harf
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = $"Parola en az bir büyük harf içermelidir."
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresLower",
				Description = $"Parola en az bir küçük harf içermelidir."
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresDigit",
				Description = $"Parola en az bir rakam(0-9) içermelidir"

			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = $"Parolalarda en az bir alfasayısal olmayan karakter bulunmalıdır."
			};
		}

	}
}
