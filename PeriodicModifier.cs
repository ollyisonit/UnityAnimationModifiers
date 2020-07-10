using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	public abstract class PeriodicModifier : LateUpdateFloatModifier
	{
		[Header("Periodic settings"), Space(10)]
		public float amplitude;
		public float frequency;
		[Range(0, 1)]
		public float phaseShift;
		public float verticalShift;
	}
}
