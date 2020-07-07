using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	class CustomCurveModifier : PeriodicModifier
	{
		public AnimationCurve curve = new AnimationCurve();

		protected override float GetRawModifiedValue()
		{
			return amplitude * curve.Evaluate(Time.realtimeSinceStartup * frequency + phaseShift / (Mathf.PI * 2)) + verticalShift;
		}
	}
}
