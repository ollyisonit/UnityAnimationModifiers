using UnityEngine;

namespace UnityAnimationModifiers
{
	public abstract class PeriodicModifier : LateUpdateFloatModifier
	{
		[Header("Periodic settings"), Space(10)]
		public float amplitude;
		public float frequency;
		[Range(0, Mathf.PI * 2)]
		public float phaseShift;
		public float verticalShift;
	}
}
