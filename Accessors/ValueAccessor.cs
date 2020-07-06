using System;

namespace UnityAnimationModifiers.Accessors
{
	[Serializable]
	public abstract class ValueAccessor<T>
	{
		public abstract T GetValue();

		public abstract void SetValue(T value);
	}
}
