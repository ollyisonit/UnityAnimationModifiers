

using System;
using System.Reflection;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class ReflectedFloatValueAccessor : ValueAccessor<float>
	{
		public UnityEngine.Object sourceObject;
		public string fieldName;
		public ReflectedValueType valueType;


		public static object GetValueFromObject(ReflectedValueType valueType, object source, string fieldName)
		{
			Type objType = source.GetType();

			switch (valueType)
			{
				case (ReflectedValueType.Field):
					FieldInfo field = objType.GetField(fieldName);
					return field.GetValue(source);
				case (ReflectedValueType.Property):
					PropertyInfo prop = objType.GetProperty(fieldName);
					return prop.GetValue(source);
				default:
					throw new NotImplementedException("No case for type " + valueType);
			}
		}

		public override float GetValue()
		{
			return (float) GetValueFromObject(valueType, sourceObject, fieldName);
		}


		public static void SetValueInObject(ReflectedValueType valueType, object source, string fieldName, object value)
		{
			Type objType = source.GetType();
			switch (valueType)
			{
				case (ReflectedValueType.Field):
					FieldInfo field = objType.GetField(fieldName);
					field.SetValue(source, value);
					break;
				case (ReflectedValueType.Property):
					PropertyInfo prop = objType.GetProperty(fieldName);
					prop.SetValue(source, value);
					break;
				default:
					throw new NotImplementedException("No case for type " + valueType);
			}
		}

		public override void SetValue(float value)
		{
			SetValueInObject(valueType, sourceObject, fieldName, value);
		}
	}
}
