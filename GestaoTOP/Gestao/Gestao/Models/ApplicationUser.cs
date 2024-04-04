using Microsoft.AspNetCore.Identity;

namespace Gestao.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Firstname { get; set; }

		public string Lastname { get; set; }

		//Atributos inseridos na tabela aspnetusers
	}
}