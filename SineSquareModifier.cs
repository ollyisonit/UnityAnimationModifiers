using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	class SineSquareModifier : PeriodicModifier
	{
		protected override float GetRawModifiedValue()
		{
			return amplitude * 2 * (Mathf.Pow(Mathf.Sin(Time.realtimeSinceStartup * frequency * Mathf.PI * 2 + phaseShift), 2) - 0.5f) + verticalShift;
		}
	}
}
