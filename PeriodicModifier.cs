using LateUpdateModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LateUpdateModifiers
{
	public abstract class PeriodicModifier : LateUpdateFloatModifier
	{
		[Header("Periodic settings"), Space(10)]
		public float amplitude;
		public float frequency;
		[Range(0, Mathf.PI * 2)]
		public float phaseShift;
		public float verticalShift;
	}
}
