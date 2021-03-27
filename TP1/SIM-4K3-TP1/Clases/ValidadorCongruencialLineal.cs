using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIM_4K3_TP1.Clases
{
	public class ValidadorCongruencialLineal {
		private int m;
		private int a;
		private int c;

		public ValidadorCongruencialLineal() {}

		public ResultadoDeValidacion validar(string m, string a, string c) {

			try
			{
				this.m = this.parsearInt(m);
				this.a = this.parsearInt(a);
				this.c = this.parsearInt(c);
			}
			catch
			{
				return new ResultadoDeValidacion(false, "Alguno de los valores no es un entero");
			}

			if (!this.validarM())
			{
				return new ResultadoDeValidacion(false, "m = 2g (con g un número entero positivos)");
			}
			if (!this.validarA())
			{
				return new ResultadoDeValidacion(false, "a = 1 + 4.k (con k un número entero positivos)");
			}
			if (!this.validarC())
			{
				return new ResultadoDeValidacion(false, "c debe ser relativamente primo a m");
			}

			return new ResultadoDeValidacion(true, "");
		}

		private bool validarM() {
			double g = Math.Log(this.m, 2);
			return esInt(g) && g > 0;
		}

		private bool validarA() {
			double k = (this.a - 1) / 4;
			return esInt(k) && k > 0;
		}

		private bool validarC() {
			return sonRelativamentePrimos(this.c, this.m);
		}

		private bool esInt(double valorDouble) {
			return (valorDouble % 1) == 0;
		}

		private bool sonRelativamentePrimos(int valor1, int valor2) {
			if (valor1 > valor2) {
				return valor1 % valor2 != 0;
			} else {
				return valor2 % valor1 != 0;
			}
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
