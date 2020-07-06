using UnityEngine;

namespace UnityAnimationModifiers.Accessors
{
	public abstract class CustomValueAccessor<T> : MonoBehaviour
	{
		public abstract T GetValue();

		public abstract void SetValue(T value);
	}
}
