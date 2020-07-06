using System;

namespace dninosores.UnityAnimationModifiers.Accessors
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

		public override float GetValues()
		{
			return modifier.intensity;
		}

		public override void SetValues(float value)
		{
			modifier.intensity = value;
		}
	}
}
