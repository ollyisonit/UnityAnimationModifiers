using LateUpdateModifiers;
using System;
using UnityEngine;

namespace Assets.Scripts.LateUpdateModifiers.Accessors
{
	[Serializable]
	public class ModifierFloatValueAccessor : ValueAccessor<float>
	{
		public LateUpdateFloatModifier modifier;
		public enum ValueType
		{
			Intensity
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
	}
}
