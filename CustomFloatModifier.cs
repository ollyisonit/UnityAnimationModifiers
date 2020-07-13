using UnityEngine;

namespace dninosores.UnityAnimationModifiers
{
	public abstract class CustomFloatModifier : MonoBehaviour
	{
		public abstract float GetModifiedValue(float time);
	}
}