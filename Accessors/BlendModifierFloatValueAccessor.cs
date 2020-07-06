using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class BlendModifierFloatValueAccessor : ValueAccessor<float>
	{
		public BlendModifier modifier;

		[HideInInspector]
		public LateUpdateFloatModifier parent;

		public BlendModifierFloatValueAccessor(LateUpdateFloatModifier parent)
		{
			if (parent == null)
			{
				throw new ArgumentException("BlendModifierFloatValueAccessor must have reference to containing modifier!");
			}
			this.parent = parent;
		}

		public override float GetValues()
		{
			return modifier.GetValueFor(this);
		}

		public override void SetValues(float value)
		{
			modifier.SetValueFor(this, value);
		}

		~BlendModifierFloatValueAccessor()
		{
			modifier.Unregister(this);
		}
	}
}
