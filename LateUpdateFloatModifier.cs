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

		public AnyFloatValueAccessor floatAccessor;


		protected override void Reset()
		{
			floatAccessor = new AnyFloatValueAccessor();
			floatAccessor.Reset(gameObject);
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
