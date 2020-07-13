using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	[Serializable]
	public abstract class PeriodicModifier : LateUpdateFloatModifier
	{
		protected PeriodicModifierSettings settings;

		public PeriodicModifier SetSettings(PeriodicModifierSettings settings)
		{
			this.settings = settings;
			return this;
		}

		protected float amplitude => settings.amplitude;
		protected float frequency => settings.frequency;
		protected float phaseShift => settings.phaseShift;
		protected float verticalShift => settings.verticalShift;
	}
}
