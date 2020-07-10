using dninosores.UnityAnimationModifiers.Accessors;
using System;
using System.Collections.Generic;

namespace dninosores.UnityAnimationModifiers
{
	public class BlendModifier : LateUpdateFloatModifier
	{
		public BlendModifierFloatAccessor[] modifiersToBlend;

		public enum BlendMode
		{
			Add = 0,
			Multiply = 1
		}

		public BlendMode blendMode;


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

			foreach (BlendModifierFloatAccessor access in modifiersToBlend)
			{
				if (access.isActiveAndEnabled)
				{
					value = Combine(value, access.GetValue(), blendMode);
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
