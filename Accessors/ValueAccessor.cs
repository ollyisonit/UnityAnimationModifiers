using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LateUpdateModifiers.Accessors
{
	[Serializable]
	public abstract class ValueAccessor<T>
	{
		public abstract T GetValue();

		public abstract void SetValue(T value);
	}
}
