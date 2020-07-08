using dninosores.UnityAccessors;
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class BlendModifierFloatAccessor : Accessor<float>
	{
		public BlendModifier modifier;

		[HideInInspector]
		public LateUpdateFloatModifier parent;

		public BlendModifierFloatAccessor(LateUpdateFloatModifier parent)
		{
			if (parent == null)
			{
				throw new ArgumentException("BlendModifierFloatAccessor must have reference to containing modifier!");
			}
			this.parent = parent;
		}

		public override float GetValue()
		{
			return modifier.GetValueFor(this);
		}

		public override void SetValue(float value)
		{
			modifier.SetValueFor(this, value);
		}

		public override void Reset(GameObject attachedObject)
		{
			modifier = attachedObject.GetComponent<BlendModifier>();
		}

		~BlendModifierFloatAccessor()
		{
			modifier.Unregister(this);
		}
	}
}
