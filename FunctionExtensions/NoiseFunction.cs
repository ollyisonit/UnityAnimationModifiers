using org.dninosores.mariuszgromada.math.mxparser;
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	/// <summary>
	/// Function of form Noise(seed, t)
	/// </summary>
	public class NoiseFunction : FunctionExtension
	{
		double t;
		double seed;

		public NoiseFunction()
		{
		}


		private NoiseFunction(double seed, double t)
		{
			this.t = t;
			this.seed = seed;
		}

		public double calculate()
		{
			return Mathf.PerlinNoise((float)seed, (float)t);
		}

		public FunctionExtension clone()
		{
			return new NoiseFunction(seed, t);
		}

		public string getParameterName(int parameterIndex)
		{
			if (parameterIndex == 0)
			{
				return "seed";
			}
			else if (parameterIndex == 1)
			{
				return "t";
			}
			else
			{
				throw new IndexOutOfRangeException("Parameter index out of range!");
			}
		}

		public int getParametersNumber()
		{
			return 2;
		}

		public void setParameterValue(int parameterIndex, double parameterValue)
		{
			if (parameterIndex == 0)
			{
				seed = parameterValue;
			}
			else if (parameterIndex == 1)
			{
				t = parameterValue;
			}
			else
			{
				throw new IndexOutOfRangeException("Parameter index out of range!");
			}
		}
	}
}
