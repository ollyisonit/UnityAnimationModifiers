﻿using dninosores.UnityValueAccessors;
using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.ValueAccessors
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

		~BlendModifierFloatValueAccessor()
		{
			modifier.Unregister(this);
		}
	}
}
