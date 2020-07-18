using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	/// <summary>
	/// Serializable container for a reference to a CustomFloatModifier.
	/// </summary>
	[Serializable]
	public class CustomFloatModifierContainer : FloatModifier
	{
		public CustomFloatModifier customModifier;
		protected override float GetRawModifiedValue()
		{
			return customModifier.GetModifiedValue(time);
		}

		public override void Reset(MonoBehaviour o)
		{
			base.Reset(o);
			customModifier = o.GetComponent<CustomFloatModifier>();
		}
	}
}