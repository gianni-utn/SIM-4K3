using System;

namespace SIM_4K3_TP1.Clases
{
	public class ResultadoDeValidacion {
		public bool esValido;
		public string mensajeDeError;

		public ResultadoDeValidacion(bool esValido, string mensajeDeError) {
			this.esValido = esValido;
			this.mensajeDeError = mensajeDeError;
		}
	}
}
