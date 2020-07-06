using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LateUpdateModifiers.Accessors
{
	[Serializable]
	public class TransformFloatValueAccessor : ValueAccessor<float>
	{
		public enum TransformType
		{
			Position,
			LocalPosition,
			Rotation,
			LocalRotation,
			LocalScale
		}

		public enum Axis
		{
			X,
			Y,
			Z
		}

		public Transform transform;
		public TransformType transformType;
		public Axis transformAxis;

		public override float GetValue()
		{
			return GetValueFromVector3(transformAxis, GetVector3FromTransform(transformType, transform));
		}

		public override void SetValue(float value)
		{
			SetVector3FromTransform(transformType, transform,
						SetValueFromVector3(transformAxis, GetVector3FromTransform(transformType, transform), value));
		}

		public Vector3 GetVector3FromTransform(TransformType ttype, Transform transform)
		{
			switch (ttype)
			{
				case (TransformType.Position):
					return transform.position;
				case (TransformType.LocalPosition):
					return transform.localPosition;
				case (TransformType.Rotation):
					return transform.eulerAngles;
				case (TransformType.LocalRotation):
					return transform.localEulerAngles;
				case (TransformType.LocalScale):
					return transform.localScale;
				default:
					throw new NotImplementedException(ttype + " not implemented.");
			}
		}


		public void SetVector3FromTransform(TransformType ttype, Transform transform, Vector3 value)
		{
			switch (ttype)
			{
				case (TransformType.Position):
					transform.position = value;
					break;
				case (TransformType.LocalPosition):
					transform.localPosition = value;
					break;
				case (TransformType.Rotation):
					transform.eulerAngles = value;
					break;
				case (TransformType.LocalRotation):
					transform.localEulerAngles = value;
					break;
				case (TransformType.LocalScale):
					transform.localScale = value;
					break;
				default:
					throw new NotImplementedException(ttype + " not implemented.");
			}
		}


		public float GetValueFromVector3(Axis axis, Vector3 vector)
		{
			switch (axis)
			{
				case (Axis.X):
					return vector.x;
				case (Axis.Y):
					return vector.y;
				case (Axis.Z):
					return vector.z;
				default:
					throw new NotImplementedException(axis + " not implemented.");
			}
		}


		public Vector3 SetValueFromVector3(Axis axis, Vector3 vector, float value)
		{
			switch (axis)
			{
				case (Axis.X):
					vector.x = value;
					return vector;
				case (Axis.Y):
					vector.y = value;
					return vector;
				case (Axis.Z):
					vector.z = value;
					return vector;
				default:
					throw new NotImplementedException(axis + " not implemented.");
			}
		}
	}
}
