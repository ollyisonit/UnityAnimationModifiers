using dninosores.UnityAccessors;
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	public class ModifierFloatAccessor : CustomFloatAccessor
	{
		public LateUpdateFloatModifier modifier;
		public enum ValueType
		{
			Intensity = 0
		}

		public ValueType valueType;

		public override float GetValue()
		{
			return modifier.intensity;
		}

		public override void SetValue(float value)
		{
			modifier.intensity = value;
		}

		public void Reset()
		{
			modifier = GetComponent<LateUpdateFloatModifier>();
		}
	}
}
