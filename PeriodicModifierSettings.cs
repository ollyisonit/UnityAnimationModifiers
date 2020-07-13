
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
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
