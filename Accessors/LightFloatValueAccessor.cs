using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class LightFloatValueAccessor : ValueAccessor<float>
	{
		public Light light;
		public ValueType valueType;
		public enum ValueType
		{
			Intensity,
			Range,
			SpotAngle,
			InnerSpotAngle,
			BounceIntensity,
			ColorTemperature
		}

		public override float GetValue()
		{
			switch (valueType)
			{
				case ValueType.InnerSpotAngle:
					return light.innerSpotAngle;
				case ValueType.Range:
					return light.range;
				case ValueType.SpotAngle:
					return light.spotAngle;
				case ValueType.Intensity:
					return light.intensity;
				case ValueType.BounceIntensity:
					return light.bounceIntensity;
				case ValueType.ColorTemperature:
					return light.colorTemperature;
				default:
					throw new NotImplementedException("Case not found for " + valueType);
			}
		}

		public override void SetValue(float value)
		{
			switch (valueType)
			{
				case ValueType.InnerSpotAngle:
					light.innerSpotAngle = value;
					break;
				case ValueType.Range:
					light.range = value;
					break;
				case ValueType.SpotAngle:
					light.spotAngle = value;
					break;
				case ValueType.Intensity:
					light.intensity = value;
					break;
				case ValueType.BounceIntensity:
					light.bounceIntensity = value;
					break;
				case ValueType.ColorTemperature:
					light.colorTemperature = value;
					break;
				default:
					throw new NotImplementedException("Case not found for " + valueType);
			}
		}
	}
}
