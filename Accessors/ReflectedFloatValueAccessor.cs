

using System;
using System.Reflection;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class ReflectedFloatValueAccessor : ValueAccessor<float>
	{
		public UnityEngine.Object sourceObject;
		public string fieldName;
		public enum ValueType
		{
			Property,
			Field
		}

		public ValueType valueType;

		public override float GetValue()
		{
			Type objType = sourceObject.GetType();

			switch (valueType)
			{
				case (ValueType.Field):
					FieldInfo field = objType.GetField(fieldName);
					return (float)field.GetValue(sourceObject);
				case (ValueType.Property):
					PropertyInfo prop = objType.GetProperty(fieldName);
					return (float)prop.GetValue(sourceObject);
				default:
					throw new NotImplementedException("No case for type " + valueType);
			}

		}

		public override void SetValue(float value)
		{
			Type objType = sourceObject.GetType();
			switch (valueType)
			{
				case (ValueType.Field):
					FieldInfo field = objType.GetField(fieldName);
					field.SetValue(sourceObject, value);
					break;
				case (ValueType.Property):
					PropertyInfo prop = objType.GetProperty(fieldName);
					prop.SetValue(sourceObject, value);
					break;
				default:
					throw new NotImplementedException("No case for type " + valueType);
			}
		}
	}
}
