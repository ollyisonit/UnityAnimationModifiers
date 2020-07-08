using dninosores.UnityAnimationModifiers.Accessors;
using dninosores.UnityEditorAttributes;
using dninosores.UnityAccessors;
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

		public AnyFloatAccessor floatAccessor;


		protected override void Reset()
		{
			floatAccessor = new AnyFloatAccessor();
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
