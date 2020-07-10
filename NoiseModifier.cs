using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	public class NoiseModifier : PeriodicModifier
	{
		[Header("Randomness"), Space(10)]
		public bool randomSeed = true;
		public float seed;

		void Awake()
		{
			if (randomSeed)
				seed = Random.Range(-100f, 100f);
		}

		protected override float GetRawModifiedValue()
		{
			return amplitude * (Mathf.PerlinNoise(time * frequency + phaseShift, seed) - 0.5f) + verticalShift;
		}
	}
}
