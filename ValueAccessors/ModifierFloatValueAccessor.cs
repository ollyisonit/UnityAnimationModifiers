using dninosores.UnityValueAccessors;
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.ValueAccessors
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

		public override void Reset(GameObject attachedObject)
		{
			modifier = attachedObject.GetComponent<LateUpdateFloatModifier>();
		}
	}
}
