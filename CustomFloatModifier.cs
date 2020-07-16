using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	/// <summary>
	/// Base class for user-defined custom modifiers.
	/// </summary>
	public abstract class CustomFloatModifier : MonoBehaviour
	{
		public abstract float GetModifiedValue(float time);
	}
}