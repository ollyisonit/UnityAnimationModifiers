using dninosores.UnityValueAccessors;
using System;

namespace dninosores.UnityAnimationModifiers.ValueAccessors
{
	[Serializable]
	public class PeriodicModifierFloatValueAccessor : ValueAccessor<float>
	{
		public PeriodicModifier modifier;
		public enum ValueType
		{
			Intensity,
			Amplitude,
			Frequency,
			PhaseShift,
			VerticalShift
		}

		public ValueType valueType;

		public override float GetValue()
		{
			switch (valueType)
			{
				case ValueType.Intensity:
					return modifier.intensity;
				case ValueType.Amplitude:
					return modifier.amplitude;
				case ValueType.Frequency:
					return modifier.frequency;
				case ValueType.PhaseShift:
					return modifier.phaseShift;
				case ValueType.VerticalShift:
					return modifier.verticalShift;
				default:
					throw new NotImplementedException("No case found for ValueType " + valueType);
			}

		}

		public override void SetValue(float value)
		{
			switch (valueType)
			{
				case ValueType.Intensity:
					modifier.intensity = value;
					break;
				case ValueType.Amplitude:
					modifier.amplitude = value;
					break;
				case ValueType.Frequency:
					modifier.frequency = value;
					break;
				case ValueType.PhaseShift:
					modifier.phaseShift = value;
					break;
				case ValueType.VerticalShift:
					modifier.verticalShift = value;
					break;
				default:
					throw new NotImplementedException("No case found for ValueType " + valueType);
			}
		}
	}
}
