using System;
using UnityEngine;

namespace ollyisonit.UnityAnimationModifiers
{
	/// <summary>
	/// Modifier that generates values using some sort of periodic function.
	/// </summary>
	[Serializable]
	public abstract class PeriodicModifier : FloatModifier
	{
		protected PeriodicModifierSettings settings;

		/// <summary>
		/// Sets the settings of the periodic function.
		/// </summary>
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
