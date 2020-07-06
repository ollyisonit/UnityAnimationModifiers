using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LateUpdateModifiers.Accessors
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
