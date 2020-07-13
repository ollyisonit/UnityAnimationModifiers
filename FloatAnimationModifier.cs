

using dninosores.UnityEditorAttributes;
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	class FloatAnimationModifier : MonoAnimationModifier<float>
	{
		public enum ModifierType
		{
			Noise,
			Sine,
			CustomCurve,
			Custom
		}

		public ModifierType modifierType;

		[ConditionalHide(new string[] { "modifierType", "modifierType", "modifierType" }, new object[]{ModifierType.Noise, ModifierType.Sine,
			ModifierType.CustomCurve }, ConditionalHideAttribute.FoldBehavior.Or)]
		public PeriodicModifierSettings periodicSettings;

		[ConditionalHide("modifierType", ModifierType.Noise, "Modifier")]
		public NoiseModifier noiseModifier;

		[ConditionalHide("modifierType", ModifierType.Sine, "Modifier")]
		public SineModifier sine;

		[ConditionalHide("modifierType", ModifierType.CustomCurve, "Modifier")]
		public CustomCurveModifier curve;




		protected override void Reset()
		{
			base.Reset();
			modifierType = ModifierType.Custom;
			periodicSettings = new PeriodicModifierSettings();
			noiseModifier = new NoiseModifier();
			noiseModifier.Reset(gameObject);
			sine = new SineModifier();
			sine.Reset(gameObject);
			curve = new CustomCurveModifier();
			curve.Reset(gameObject);
		}


		public override LateUpdateModifier<float> modifier
		{
			get
			{
				switch (modifierType)
				{
					case (ModifierType.Noise):
						return noiseModifier.SetSettings(periodicSettings);
					case (ModifierType.Sine):
						return sine.SetSettings(periodicSettings);
					case (ModifierType.CustomCurve):
						return curve.SetSettings(periodicSettings);
					default:
						throw new NotImplementedException("Case not found for ModifierType " + modifierType);
				}

			}
		}
	}
}
