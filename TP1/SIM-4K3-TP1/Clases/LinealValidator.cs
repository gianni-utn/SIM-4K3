using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIM_4K3_TP1.Clases
{
	public class LinealValidator
	{
		private string seed;
		private string a;
		private string m;
		private string c;

		public LinealValidator(string seed, string a, string m, string c)
		{
			this.seed = seed;
			this.a = a;
			this.m = m;
			this.c = c;
		}

		public bool isValidForLineal()
		{
			return this.validateGForLineal() && this.validateAForLineal() && this.validateCForLineal();
		}

		private bool validateGForLineal()
		{
			int intm;
			if (int.TryParse(this.m, out intm))
			{
				return false;
			}
			double g = Math.Log(intm, 2);
			return isInt(g) && g > 0;
		}

		private bool validateAForLineal()
		{
			int inta;
			if (int.TryParse(this.a, out inta))
			{
				return false;
			}
			double k = (inta - 1) / 4;
			return isInt(k) && k > 0;
		}

		private bool validateCForLineal()
		{
			int intc;
			if (int.TryParse(this.c, out intc))
			{
				return false;
			}

			int intm;
			if (int.TryParse(this.m, out intm))
			{
				return false;
			}

			if (intc > intm)
			{
				return intc % intm != 0;
			}
			else
			{
				return intm % intc != 0;
			}
		}

		private bool isInt(double n)
		{
			return (n % 1) == 0;
		}
	}
}
