using Assets.Scripts.LateUpdateModifiers.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LateUpdateModifiers.CustomAccessors
{
	class AlphaCorrectorAccessor : CustomFloatValueAccessor
	{
		public AlphaCorrector alphaCorrector;
		public override float GetValue()
		{
			return alphaCorrector.Alpha;
		}

		public override void SetValue(float value)
		{
			alphaCorrector.Alpha = value;
		}
	}
}
