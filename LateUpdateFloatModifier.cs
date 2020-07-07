using dninosores.UnityAnimationModifiers.ValueAccessors;
using dninosores.UnityEditorAttributes;
using dninosores.UnityValueAccessors;
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

		//#region Modifier_Modifiers
		//public enum ModifierType
		//{
		//	GeneralFloat,
		//	Periodic,
		//	Blend
		//}

		//[ConditionalHide("accessType", AccessType.Modifier)]
		//public ModifierType modifierType;

		//[ConditionalHide(new string[] { "accessType", "modifierType" }, new object[] { AccessType.Modifier, ModifierType.GeneralFloat })]
		//public ModifierFloatValueAccessor modifierToModify;

		//[ConditionalHide(new string[] { "accessType", "modifierType" }, new object[] { AccessType.Modifier, ModifierType.Periodic })]
		//public PeriodicModifierFloatValueAccessor periodicModifierToModify;

		//[ConditionalHide(new string[] { "accessType", "modifierType" }, new object[] { AccessType.Modifier, ModifierType.Blend })]
		//public BlendModifierFloatValueAccessor blendToModify;

		//#endregion

		public AnyFloatValueAccessor floatAccessor;
	
		/// <summary>
		/// Default to accessing components attached to the same object as this script.
		/// </summary>
		//protected virtual void Reset()
		//{
		//	transformToModify = new TransformFloatValueAccessor();
		//	lightToModify = new LightFloatValueAccessor();
		//	rectToModify = new RectTransformFloatValueAccessor();
		//	imageToModify = new ImageColorFloatValueAccessor();
		//	lightColorToModify = new LightColorFloatValueAccessor();
		//	modifierToModify = new ModifierFloatValueAccessor();
		//	periodicModifierToModify = new PeriodicModifierFloatValueAccessor();
		//	blendToModify = new BlendModifierFloatValueAccessor(this);
		//	reflectedAccessor = new ReflectedFloatValueAccessor();
		//	nestedReflectedAccessor = new NestedReflectedFloatValueAccessor();

		//	transformToModify.transform = transform;
		//	lightToModify.light = GetComponent<Light>();
		//	rectToModify.rectTransform = GetComponent<RectTransform>();
		//	imageToModify.image = GetComponent<Image>();
		//	lightColorToModify.light = GetComponent<Light>();
		//	modifierToModify.modifier = GetComponent<LateUpdateFloatModifier>();
		//	periodicModifierToModify.modifier = GetComponent<PeriodicModifier>();
		//	blendToModify.modifier = GetComponent<BlendModifier>();
		//}

		protected virtual void OnValidate()
		{
			
			//blendToModify.parent = this;
		}

		protected override float GetValue()
		{
			return floatAccessor.GetValue();
		}

		protected override void SetValue(float value)
		{
			floatAccessor.SetValue(value);
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
