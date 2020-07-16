using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	/// <summary>
	/// Modifies a value based on a sine wave.
	/// </summary>
	[Serializable]
	class SineModifier : PeriodicModifier
	{
		protected override float GetRawModifiedValue()
		{
			return amplitude * Mathf.Sin(time * frequency * Mathf.PI * 2 + phaseShift * Mathf.PI * 2) + verticalShift;
		}
	}
}
