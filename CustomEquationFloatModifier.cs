using dninosores.UnityAccessors;
using org.dninosores.mariuszgromada.math.mxparser;
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	[Serializable]
	class CustomEquationFloatModifier : LateUpdateFloatModifier
	{
		[Serializable]
		public class Variable
		{
			[Tooltip("The name of the variable to use when referenced in the equation")]
			public string name;
			[Tooltip("The value to use for the variable when referenced in the equation")]
			public AnyFloatAccessor value;

			public Variable()
			{
				name = "";
				value = new AnyFloatAccessor();
			}

			public Argument GetArgument()
			{
				return new Argument(name, new AccessorArgument(value));
			}


		}


		protected class TimeArgument : ArgumentExtension
		{
			public double t;
			public ArgumentExtension clone()
			{
				TimeArgument twin = new TimeArgument();
				twin.t = t;
				return twin;
			}

			public double getArgumentValue()
			{
				return t;
			}
		}

		[Tooltip("Use t in equation to refer to current time in seconds. \nExample: 'sin(t + 2) * 3'")]
		public string equation;

		[Tooltip("Should the equation be allowed to change while the game is running?")]
		public bool dynamic;

		[Tooltip("Variables (other than t) that are referenced in the equation, and what values they should be interpreted as")]
		public Variable[] variables;

		private Expression expression;
		private TimeArgument t;

		private float lastModifiedValue;

		protected override float GetRawModifiedValue()
		{
			t.t = time;
			if (dynamic)
			{
				RecalculateExpression();
			}
			if (expression == null)
			{
				return lastModifiedValue;
			}
			else
			{
				lastModifiedValue = (float)expression.calculate();
				return lastModifiedValue;
			}
		}


		public override void Reset(GameObject o)
		{
			base.Reset(o);
			equation = "";
			dynamic = false;
			variables = new Variable[0];
		}


		public override void Awake()
		{
			base.Awake();
			t = new TimeArgument();
			RecalculateExpression();
		}

		private void RecalculateExpression()
		{
			PrimitiveElement[] elements = new PrimitiveElement[variables.Length + 2];
			elements[0] = new Argument("t", t);
			elements[1] = new Function("Noise", new NoiseFunction());
			for (int i = 2; i < variables.Length + 2; i++)
			{
				elements[i] = variables[i - 2].GetArgument();
			}

			expression = new Expression(equation, elements);
			if (!expression.checkSyntax())
			{
				expression = null;
				Debug.LogWarning("Expression '" + equation + "' could not be parsed!");
			}
		}
	}
}
