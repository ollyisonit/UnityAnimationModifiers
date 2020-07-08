using dninosores.UnityAnimationModifiers.Accessors;
using System;
using System.Collections.Generic;

namespace dninosores.UnityAnimationModifiers
{
	public class BlendModifier : LateUpdateFloatModifier
	{
		private Dictionary<BlendModifierFloatAccessor, float> values;

		public enum BlendMode
		{
			Add,
			Multiply
		}

		public BlendMode blendMode;


		public float GetValueFor(BlendModifierFloatAccessor mod)
		{
			Register(mod);
			return values[mod];
		}

		public void SetValueFor(BlendModifierFloatAccessor mod, float value)
		{
			Register(mod);
			values[mod] = value;
		}

		public void Register(BlendModifierFloatAccessor modifier)
		{
			if (values == null)
			{
				values = new Dictionary<BlendModifierFloatAccessor, float>();
			}

			if (!values.ContainsKey(modifier))
			{
				values.Add(modifier, 0f);
			}
		}

		public void Unregister(BlendModifierFloatAccessor modifier)
		{
			if (values != null && values.ContainsKey(modifier))
			{
				values.Remove(modifier);
			}
		}

		protected override float GetRawModifiedValue()
		{
			float value;
			switch (blendMode)
			{
				case BlendMode.Add:
					value = 0;
					break;
				case BlendMode.Multiply:
					value = 1;
					break;
				default:
					throw new NotImplementedException("Case not found for " + blendMode);
			}

			foreach (KeyValuePair<BlendModifierFloatAccessor, float> pair in values)
			{
				if (pair.Key.parent.isActiveAndEnabled)
				{
					value = Combine(value, pair.Value, blendMode);
				}
			}

			return value;
		}

		private float Combine(float left, float right, BlendMode mode)
		{
			switch (blendMode)
			{
				case BlendMode.Add:
					return left + right;
				case BlendMode.Multiply:
					return left * right;
				default:
					throw new NotImplementedException("Case not found for " + blendMode);
			}
		}
	}
}
