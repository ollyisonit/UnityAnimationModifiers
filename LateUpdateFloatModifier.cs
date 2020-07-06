using dninosores.UnityAnimationModifiers.ValueAccessors;
using dninosores.UnityValueAccessors;
using dninosores.UnityValueAccessors.PropertyDrawers;
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
			Custom,
			Reflected
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

		#region ReflectedModifiers

		public enum ReflectionType
		{
			Simple,
			Nested
		}

		[ShowWhen("accessType", AccessType.Reflected)]
		public ReflectionType reflectionType;

		[ShowWhen(new string[] { "accessType", "reflectionType" }, new object[] { AccessType.Reflected, ReflectionType.Simple })]
		public ReflectedFloatValueAccessor reflectedAccessor;

		[ShowWhen(new string[] { "accessType", "reflectionType" }, new object[] { AccessType.Reflected, ReflectionType.Nested })]
		public NestedReflectedFloatValueAccessor nestedReflectedAccessor;

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
			reflectedAccessor = new ReflectedFloatValueAccessor();
			nestedReflectedAccessor = new NestedReflectedFloatValueAccessor();

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

		protected override float GetValue()
		{
			switch (accessType)
			{
				case AccessType.Transform:
					return transformToModify.GetValue();
				case AccessType.RectTransform:
					return rectToModify.GetValue();
				case AccessType.Light:
					switch (lightAttribute)
					{
						case LightAttribute.General:
							return lightToModify.GetValue();
						case LightAttribute.Color:
							return lightColorToModify.GetValue();
						default:
							throw new NotImplementedException("No case for LightAttribute " + lightAttribute);
					}
				case AccessType.ImageColor:
					return imageToModify.GetValue();
				case AccessType.Modifier:
					switch (modifierType)
					{
						case ModifierType.GeneralFloat:
							return modifierToModify.GetValue();
						case ModifierType.Periodic:
							return periodicModifierToModify.GetValue();
						case ModifierType.Blend:
							return blendToModify.GetValue();
						default:
							throw new NotImplementedException("No case for ModifierType " + modifierType);
					}
				case AccessType.Custom:
					return customAccessor.GetValue();
				case AccessType.Reflected:
					switch (reflectionType)
					{
						case (ReflectionType.Simple):
							return reflectedAccessor.GetValue();
						case (ReflectionType.Nested):
							return nestedReflectedAccessor.GetValue();
						default:
							throw new NotImplementedException("No case for GetValue for " + reflectionType);
					}
				default:
					throw new NotImplementedException("No case for GetValue for accessType " + accessType + "!");
			}
		}

		protected override void SetValue(float value)
		{
			switch (accessType)
			{
				case AccessType.Transform:
					transformToModify.SetValue(value);
					break;
				case AccessType.RectTransform:
					rectToModify.SetValue(value);
					break;
				case AccessType.Light:
					switch (lightAttribute)
					{
						case LightAttribute.General:
							lightToModify.SetValue(value);
							break;
						case LightAttribute.Color:
							lightColorToModify.SetValue(value);
							break;
						default:
							throw new NotImplementedException("No case found for LightAttribute " + lightAttribute);
					}
					break;
				case AccessType.ImageColor:
					imageToModify.SetValue(value);
					break;
				case AccessType.Modifier:
					switch (modifierType)
					{
						case ModifierType.GeneralFloat:
							modifierToModify.SetValue(value);
							break;
						case ModifierType.Periodic:
							periodicModifierToModify.SetValue(value);
							break;
						case ModifierType.Blend:
							blendToModify.SetValue(value);
							break;
						default:
							throw new NotImplementedException("No case found for ModifierType " + modifierType);
					}
					break;
				case AccessType.Custom:
					customAccessor.SetValue(value);
					break;
				case AccessType.Reflected:
					switch (reflectionType)
					{
						case (ReflectionType.Simple):
							reflectedAccessor.SetValue(value);
							break;
						case (ReflectionType.Nested):
							nestedReflectedAccessor.SetValue(value);
							break;
						default:
							throw new NotImplementedException("No case for GetValue for " + reflectionType);
					}
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
