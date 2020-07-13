﻿using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	[Serializable]
	class CustomCurveModifier : PeriodicModifier
	{
		public AnimationCurve curve = new AnimationCurve();

		protected override float GetRawModifiedValue()
		{
			return amplitude * curve.Evaluate(base.time * frequency + 
				phaseShift * (curve.postWrapMode == WrapMode.PingPong ? 2 : 1)) + verticalShift;
		}
	}
}
