using ollyisonit.UnityEditorAttributes;
using System;
using UnityEngine;

namespace ollyisonit.UnityAnimationModifiers
{
	/// <summary>
	/// Modifier that generates random values using Perlin noise.
	/// </summary>
	[Serializable]
	public class NoiseModifier : PeriodicModifier
	{
		[Header("Randomness")]
		public bool randomSeed = true;
		[ConditionalHide("randomSeed", false)]
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
