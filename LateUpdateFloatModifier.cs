using dninosores.UnityAnimationModifiers.Accessors;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace dninosores.UnityAnimationModifiers
{
	public abstract class LateUpdateFloatModifier : LateUpdateModifier<float>
	{
		public enum AccessType
		{
			Transform,
			RectTransform,
			Light,
			ImageColor,
			Modifier,
			Custom
		}

		[Header("Accessor"), Space(10)]
		public AccessType accessType;

		[ShowWhen("accessType", AccessType.Transform)]
		public TransformFloatValueAccessor transformToModify;

		#region LightModifiers
		public enum LightAttribute
		{
			General,
			Color
		}

		[ShowWhen(new string[] { "accessType" }, new object[] { AccessType.Light })]
		public LightAttribute lightAttribute;

		[ShowWhen(new string[] { "accessType", "lightAttribute" }, new object[] { AccessType.Light, LightAttribute.General })]
		public LightFloatValueAccessor lightToModify;

		[ShowWhen(new string[] { "accessType", "lightAttribute" }, new object[] { AccessType.Light, LightAttribute.Color })]
		public LightColorFloatValueAccessor lightColorToModify;

		#endregion

		[ShowWhen("accessType", AccessType.RectTransform)]
		public RectTransformFloatValueAccessor rectToModify;

		[ShowWhen("accessType", AccessType.Custom), Tooltip("Make a script that extends CustomFloatValueAccessor and reference it here")]
		public CustomFloatValueAccessor customAccessor;

		[ShowWhen("accessType", AccessType.ImageColor)]
		public ImageColorFloatValueAccessor imageToModify;

		#region Modifier_Modifiers
		public enum ModifierType
		{
			GeneralFloat,
			Periodic,
			Blend
		}

		[ShowWhen("accessType", AccessType.Modifier)]
		public ModifierType modifierType;

		[ShowWhen(new string[] { "accessType", "modifierType" }, new object[] { AccessType.Modifier, ModifierType.GeneralFloat })]
		public ModifierFloatValueAccessor modifierToModify;

		[ShowWhen(new string[] { "accessType", "modifierType" }, new object[] { AccessType.Modifier, ModifierType.Periodic })]
		public PeriodicModifierFloatValueAccessor periodicModifierToModify;

		[ShowWhen(new string[] { "accessType", "modifierType" }, new object[] { AccessType.Modifier, ModifierType.Blend })]
		public BlendModifierFloatValueAccessor blendToModify;

		#endregion

		/// <summary>
		/// Default to accessing components attached to the same object as this script.
		/// </summary>
		protected virtual void Reset()
		{
			transformToModify = new TransformFloatValueAccessor();
			lightToModify = new LightFloatValueAccessor();
			rectToModify = new RectTransformFloatValueAccessor();
			imageToModify = new ImageColorFloatValueAccessor();
			lightColorToModify = new LightColorFloatValueAccessor();
			modifierToModify = new ModifierFloatValueAccessor();
			periodicModifierToModify = new PeriodicModifierFloatValueAccessor();
			blendToModify = new BlendModifierFloatValueAccessor(this);

			transformToModify.transform = transform;
			lightToModify.light = GetComponent<Light>();
			rectToModify.rectTransform = GetComponent<RectTransform>();
			imageToModify.image = GetComponent<Image>();
			lightColorToModify.light = GetComponent<Light>();
			modifierToModify.modifier = GetComponent<LateUpdateFloatModifier>();
			periodicModifierToModify.modifier = GetComponent<PeriodicModifier>();
			blendToModify.modifier = GetComponent<BlendModifier>();
		}

		protected virtual void OnValidate()
		{
			blendToModify.parent = this;
		}

		protected override float[] GetValues()
		{
			switch (accessType)
			{
				case AccessType.Transform:
					return transformToModify.GetValues();
				case AccessType.RectTransform:
					return rectToModify.GetValues();
				case AccessType.Light:
					switch (lightAttribute)
					{
						case LightAttribute.General:
							return lightToModify.GetValues();
						case LightAttribute.Color:
							return lightColorToModify.GetValues();
						default:
							throw new NotImplementedException("No case for LightAttribute " + lightAttribute);
					}
				case AccessType.ImageColor:
					return imageToModify.GetValues();
				case AccessType.Modifier:
					switch (modifierType)
					{
						case ModifierType.GeneralFloat:
							return modifierToModify.GetValues();
						case ModifierType.Periodic:
							return periodicModifierToModify.GetValues();
						case ModifierType.Blend:
							return blendToModify.GetValues();
						default:
							throw new NotImplementedException("No case for ModifierType " + modifierType);
					}
				case AccessType.Custom:
					return customAccessor.GetValue();
				default:
					throw new NotImplementedException("No case for GetValue for accessType " + accessType + "!");
			}
		}

		protected override void SetValues(float[] values)
		{
			switch (accessType)
			{
				case AccessType.Transform:
					transformToModify.SetValues(value);
					break;
				case AccessType.RectTransform:
					rectToModify.SetValues(value);
					break;
				case AccessType.Light:
					switch (lightAttribute)
					{
						case LightAttribute.General:
							lightToModify.SetValues(value);
							break;
						case LightAttribute.Color:
							lightColorToModify.SetValues(value);
							break;
						default:
							throw new NotImplementedException("No case found for LightAttribute " + lightAttribute);
					}
					break;
				case AccessType.ImageColor:
					imageToModify.SetValues(value);
					break;
				case AccessType.Modifier:
					switch (modifierType)
					{
						case ModifierType.GeneralFloat:
							modifierToModify.SetValues(value);
							break;
						case ModifierType.Periodic:
							periodicModifierToModify.SetValues(value);
							break;
						case ModifierType.Blend:
							blendToModify.SetValues(value);
							break;
						default:
							throw new NotImplementedException("No case found for ModifierType " + modifierType);
					}
					break;
				case AccessType.Custom:
					customAccessor.SetValue(value);
					break;
				default:
					throw new NotImplementedException("No case for SetValue for accessType " + accessType + "!");
			}
		}

		protected abstract float GetRawModifiedValue();

		protected override float GetModifiedValue(float originalValue)
		{
			if (additive)
			{
				return originalValue + GetRawModifiedValue() * intensity;
			}
			else
			{
				return GetRawModifiedValue() * intensity;
			}
		}

	}
}
