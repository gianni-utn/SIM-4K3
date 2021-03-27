using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIM_4K3_TP1.Clases
{
	public class ValidadorCongruencialMultiplicativo {
		private int semilla;
		private int a;
		private int m;

		public ValidadorCongruencialMultiplicativo() {}

		public ResultadoDeValidacion validar(string semilla, string a, string m) {

			try {
				this.semilla = this.parsearInt(semilla);
				this.a = this.parsearInt(a);
				this.m = this.parsearInt(m);
			} catch {
				return new ResultadoDeValidacion(false, "Alguno de los valores no es un entero");
			}

			if (!this.validarM())
			{
				return new ResultadoDeValidacion(false, "m = 2g (con g un número entero positivos)");
			}
			if (!this.validarA())
			{
				return new ResultadoDeValidacion(false, "a = 3 + 8.k (con k un número entero positivos)");
			}
			if (!this.validarSemilla())
			{
				return new ResultadoDeValidacion(false, "La semilla debe ser un número impar");
			}

			return new ResultadoDeValidacion(true, "");
		}

		private bool validarM() {
			double g = Math.Log(this.m, 2);
			return esInt(g) && g > 0;
		}

		private bool validarA() {
			double k = (this.a - 3) / 8;
			return esInt(k) && k > 0;
		}

		private bool validarSemilla() {
			return esImpar(this.semilla);
		}

		private bool esInt(double valorDouble) {
			return (valorDouble % 1) == 0;
		}

		private bool esImpar(int valor) {
			return valor % 2 != 0;
		}

		private int parsearInt(string valorString) {
			int valorInt;
			bool esInt = int.TryParse(valorString, out valorInt);
			if(!esInt) {
				throw new Exception(); 
			}
			return valorInt;
		}
	}
}
