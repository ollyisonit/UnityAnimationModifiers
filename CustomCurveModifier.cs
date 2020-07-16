using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	/// <summary>
	/// Modifier that uses an animation curve supplied by the user.
	/// </summary>
	[Serializable]
	class CustomCurveModifier : PeriodicModifier
	{
		[Tooltip("Animation curve that defines the shape of the modifier's function. Make sure to set the end behavior of the curve to" +
			"loop or ping-pong if you want the modifier to play continuously.")]
		public AnimationCurve curve = new AnimationCurve();

		protected override float GetRawModifiedValue()
		{
			return amplitude * curve.Evaluate(base.time * frequency + 
				phaseShift * (curve.postWrapMode == WrapMode.PingPong ? 2 : 1)) + verticalShift;
		}
	}
}
