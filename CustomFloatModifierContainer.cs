using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	[Serializable]
	public class CustomFloatModifierContainer : LateUpdateFloatModifier
	{
		public CustomFloatModifier customModifier;
		protected override float GetRawModifiedValue()
		{
			return customModifier.GetModifiedValue(time);
		}

		public override void Reset(GameObject o)
		{
			base.Reset(o);
			customModifier = o.GetComponent<CustomFloatModifier>();
		}
	}
}