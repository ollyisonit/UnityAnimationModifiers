using UnityEngine;

namespace ollyisonit.UnityAnimationModifiers
{
	/// <summary>
	/// Base class for user-defined custom modifiers.
	/// </summary>
	public abstract class CustomFloatModifier : MonoBehaviour
	{
		/// <summary>
		/// Gets the raw modified value given the time.
		/// </summary>
		public abstract float GetModifiedValue(float time);
	}
}