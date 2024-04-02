﻿using ollyisonit.UnityEditorAttributes;
using ollyisonit.UnityAccessors;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ollyisonit.UnityAnimationModifiers
{
	/// <summary>
	/// Base class for FloatModifiers that modify AnyFloatAccessors.
	/// </summary>
	[Serializable]
	public abstract class FloatModifier : Modifier<float>
	{
		public AnyFloatAccessor floatAccessor;


		public override void Reset(MonoBehaviour o)
		{
			base.Reset(o);
			floatAccessor = new AnyFloatAccessor();
			floatAccessor.Reset(o);
		}


		protected override float GetValue()
		{
			return floatAccessor.Value;
		}

		protected override void SetValue(float value)
		{
			floatAccessor.Value = (value);
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
