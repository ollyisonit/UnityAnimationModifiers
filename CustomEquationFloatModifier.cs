using org.dninosores.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	[Serializable]
	class CustomEquationFloatModifier : LateUpdateFloatModifier
	{
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
		}


		public override void Awake()
		{
			base.Awake();
			t = new TimeArgument();
			RecalculateExpression();
		}

		private void RecalculateExpression()
		{
			expression = new Expression(equation, new Argument("t", t), new Function("Noise", new NoiseFunction()));
			if (!expression.checkSyntax())
			{
				expression = null;
			}
		}
	}
}
