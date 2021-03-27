using System;

namespace SIM_4K3_TP1.Clases
{
	public class ResultadoDeValidacion {
		private bool esValido;
		private string mensajeDeError;

		public ResultadoDeValidacion(bool esValido, string mensajeDeError) {
			this.esValido = esValido;
			this.mensajeDeError = mensajeDeError;
		}
	}
}
