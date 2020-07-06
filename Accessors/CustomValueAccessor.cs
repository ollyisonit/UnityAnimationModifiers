using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LateUpdateModifiers.Accessors
{
	public abstract class CustomValueAccessor<T> : MonoBehaviour
	{
		public abstract T GetValue();

		public abstract void SetValue(T value);
	}
}
