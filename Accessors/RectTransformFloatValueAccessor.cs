using System;
using UnityEngine;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[Serializable]
	public class RectTransformFloatValueAccessor : ValueAccessor<float>
	{
		public RectTransform rectTransform;
		public Axis axis;
		public ValueType valueType;

		public enum Axis
		{
			X, Y
		}

		public enum ValueType
		{
			anchoredPosition,
			anchorMax,
			anchorMin,
			offsetMax,
			offsetMin,
			pivot,
			sizeDelta
		}

		private float GetVector(Axis axis, Vector2 v)
		{
			switch (axis)
			{
				case Axis.X:
					return v.x;
				case Axis.Y:
					return v.y;
				default:
					throw new NotImplementedException("No case found for axis " + axis);
			}
		}

		private float GetVector(Vector2 v)
		{
			return GetVector(axis, v);
		}


		private Vector2 SetVector(Axis axis, Vector2 v, float value)
		{
			switch (axis)
			{
				case Axis.X:
					v.x = value;
					break;
				case Axis.Y:
					v.y = value;
					break;
				default:
					throw new NotImplementedException("No case found for axis " + axis);
			}
			return v;
		}

		private Vector2 SetVector(Vector2 v, float value)
		{
			return SetVector(axis, v, value);
		}

		public override float GetValues()
		{
			switch (valueType)
			{
				case ValueType.anchoredPosition:
					return GetVector(rectTransform.anchoredPosition);
				case ValueType.anchorMax:
					return GetVector(rectTransform.anchorMax);
				case ValueType.anchorMin:
					return GetVector(rectTransform.anchorMin);
				case ValueType.offsetMax:
					return GetVector(rectTransform.offsetMax);
				case ValueType.offsetMin:
					return GetVector(rectTransform.offsetMin);
				case ValueType.pivot:
					return GetVector(rectTransform.pivot);
				case ValueType.sizeDelta:
					return GetVector(rectTransform.sizeDelta);
				default:
					throw new NotImplementedException("Case not found for ValueType " + valueType);
			}
		}

		public override void SetValues(float value)
		{
			Vector2 Set(Vector2 original)
			{
				return SetVector(original, value);
			}

			switch (valueType)
			{
				case ValueType.anchoredPosition:
					rectTransform.anchoredPosition = Set(rectTransform.anchoredPosition);
					break;
				case ValueType.anchorMax:
					rectTransform.anchorMax = Set(rectTransform.anchorMax);
					break;
				case ValueType.anchorMin:
					rectTransform.anchorMin = Set(rectTransform.anchorMin);
					break;
				case ValueType.offsetMax:
					rectTransform.offsetMax = Set(rectTransform.offsetMax);
					break;
				case ValueType.offsetMin:
					rectTransform.offsetMin = Set(rectTransform.offsetMin);
					break;
				case ValueType.pivot:
					rectTransform.pivot = Set(rectTransform.pivot);
					break;
				case ValueType.sizeDelta:
					rectTransform.sizeDelta = Set(rectTransform.sizeDelta);
					break;
				default:
					throw new NotImplementedException("Case not found for ValueType " + valueType);
			}
		}
	}
}
