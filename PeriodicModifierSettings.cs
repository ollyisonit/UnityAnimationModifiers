
using System;
using UnityEngine;

namespace ollyisonit.UnityAnimationModifiers
{
	/// <summary>
	/// Stores amplitude, frequency, phase shift, and vertical shift of a periodic modifier.
	/// </summary>
	[Serializable]
	public class PeriodicModifierSettings
	{
		public float amplitude;
		public float frequency;
		[Range(0, 1)]
		public float phaseShift;
		public float verticalShift;
	}
}
