

using ollyisonit.UnityEditorAttributes;
using System;
using UnityEngine;

namespace ollyisonit.UnityAnimationModifiers
{
	/// <summary>
	/// Animation modifier that affects a float value.
	/// </summary>
	class FloatAnimationModifier : MonoAnimationModifier<float>
	{
		public enum ModifierType
		{
			Noise,
			Sine,
			CustomCurve,
			CustomEquation,
			Custom
		}

		[Tooltip("What type of function should be used to modify the value?")]
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

		[ConditionalHide("modifierType", ModifierType.CustomEquation, "Modifier")]
		public CustomEquationFloatModifier equation;

		[ConditionalHide("modifierType", ModifierType.Custom, "Modifier")]
		public CustomFloatModifierContainer custom;



		protected override void Reset()
		{
			base.Reset();
			modifierType = ModifierType.CustomEquation;
			periodicSettings = new PeriodicModifierSettings();
			noiseModifier = new NoiseModifier();
			noiseModifier.Reset(this);
			sine = new SineModifier();
			sine.Reset(this);
			curve = new CustomCurveModifier();
			curve.Reset(this);
			equation = new CustomEquationFloatModifier();
			equation.Reset(this);
			custom = new CustomFloatModifierContainer();
			custom.Reset(this);
		}


		public override Modifier<float> modifier
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
					case (ModifierType.CustomEquation):
						return equation;
					case (ModifierType.Custom):
						return custom;
					default:
						throw new NotImplementedException("Case not found for ModifierType " + modifierType);
				}

			}
		}
	}
}
