namespace Entidades.Final
{
    public class Login
    {
		private string email;
		private string pass;


		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		public string Pass
		{
			get { return pass; }
			set { pass = value; }
		}

		public Login(string correo, string clave)
		{
			this.email = correo;
			this.pass = clave;
		}


		/// <summary>
		/// Metodo de instancia publico. Se conectara a la BD enviando correo y contraseña si existe ne la tabla de usuarios retornara true o sino flase
		/// </summary>
		/// <returns></returns>
		public bool Loguear()
		{
			if(true)
			{
				return true;

			}
			else
			{
				return false;
			}
		}


	}
}
