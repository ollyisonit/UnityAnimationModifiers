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
			Transform = 0,
			RectTransform = 1,
			Light = 2,
			ImageColor = 3,
			Modifier = 4,
			Custom = 5,
			Reflected = 6
		}

		public AnyFloatAccessor floatAccessor;


		protected override void Reset()
		{
			base.Reset();
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
