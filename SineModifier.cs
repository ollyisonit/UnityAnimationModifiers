using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	class SineModifier : PeriodicModifier
	{
		protected override float GetRawModifiedValue()
		{
			return amplitude * Mathf.Sin(time * frequency * Mathf.PI * 2 + phaseShift * Mathf.PI * 2) + verticalShift;
		}
	}
}
