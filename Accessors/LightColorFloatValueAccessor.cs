using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class LightColorFloatValueAccessor : ColorFloatValueAccessor
	{
		public Light light;
		protected override Color GetColor()
		{
			return light.color;
		}

		protected override void SetColor(Color c)
		{
			light.color = c;
		}
	}
}
