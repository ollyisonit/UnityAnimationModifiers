using Assets.Scripts.LateUpdateModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LateUpdateModifiers
{
	class SineModifier : PeriodicModifier
	{
		protected override float GetRawModifiedValue()
		{
			return amplitude * Mathf.Sin(Time.realtimeSinceStartup * frequency * Mathf.PI * 2 + phaseShift) + verticalShift;
		}
	}
}
