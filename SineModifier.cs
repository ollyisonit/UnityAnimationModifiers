using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	[Serializable]
	class SineModifier : PeriodicModifier
	{
		protected override float GetRawModifiedValue()
		{
			return amplitude * Mathf.Sin(time * frequency * Mathf.PI * 2 + phaseShift * Mathf.PI * 2) + verticalShift;
		}
	}
}
