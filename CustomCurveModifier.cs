using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	class CustomCurveModifier : PeriodicModifier
	{
		public AnimationCurve curve = new AnimationCurve();

		protected override float GetRawModifiedValue()
		{
			return amplitude * curve.Evaluate(base.time * frequency + phaseShift) + verticalShift;
		}
	}
}
