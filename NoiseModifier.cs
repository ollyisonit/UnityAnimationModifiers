using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	[Serializable]
	public class NoiseModifier : PeriodicModifier
	{
		[Header("Randomness")]
		public bool randomSeed = true;
		public float seed;


		public override void Awake()
		{
			if (randomSeed)
				seed = UnityEngine.Random.Range(-100f, 100f);
		}

		protected override float GetRawModifiedValue()
		{
			return amplitude * (Mathf.PerlinNoise(time * frequency + phaseShift, seed) - 0.5f) + verticalShift;
		}
	}
}
