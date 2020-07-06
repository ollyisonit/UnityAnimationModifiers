using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class NestedReflectedFloatValueAccessor : ValueAccessor<float>
	{
		public UnityEngine.Object sourceObject;
		public ReflectionInfo[] path;

		[Serializable]
		public class ReflectionInfo
		{
			public ReflectedValueType valueType;
			public string name;
		}

		public override float GetValue()
		{
			object current = sourceObject;
			for (int i = 0; i < path.Length - 1; i++)
			{
				ReflectionInfo info = path[i];
				current = ReflectedFloatValueAccessor.GetValueFromObject(info.valueType, current, info.name);
			}
			ReflectionInfo last = path[path.Length - 1];
			return (float) ReflectedFloatValueAccessor.GetValueFromObject(last.valueType, current, last.name);

		}

		public override void SetValue(float value)
		{
			object[] objects = new object[path.Length + 1];
			objects[0] = sourceObject;
			for (int i = 0; i < path.Length; i++)
			{
				ReflectionInfo info = path[i];
				objects[i+1] = ReflectedFloatValueAccessor.GetValueFromObject(info.valueType, objects[i], info.name);
			}
			objects[objects.Length - 1] = value;
			for (int i = objects.Length - 2; i >= 0; i--)
			{
				ReflectedFloatValueAccessor.SetValueInObject(path[i].valueType, objects[i], path[i].name, objects[i + 1]);
			}
		}
	}
}
