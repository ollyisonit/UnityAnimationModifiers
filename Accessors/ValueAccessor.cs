using System;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public abstract class ValueAccessor<T>
	{
		public abstract T[] GetValues();

		public abstract void SetValues(T[] values);
	}
}
