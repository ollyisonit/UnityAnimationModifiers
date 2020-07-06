using UnityEngine;

namespace UnityAnimationModifiers
{
	class SineModifier : PeriodicModifier
	{
		protected override float GetRawModifiedValue()
		{
			return amplitude * Mathf.Sin(Time.realtimeSinceStartup * frequency * Mathf.PI * 2 + phaseShift) + verticalShift;
		}
	}
}
