using System;
using UnityEngine;

namespace UnityAnimationModifiers.Accessors
{
	public abstract class ColorFloatValueAccessor : ValueAccessor<float>
	{
		public enum ColorChannel
		{
			A,
			R,
			G, 
			B,
		}
		public ColorChannel colorChannel;

		protected abstract Color GetColor();

		protected abstract void SetColor(Color c);


		public override float GetValue()
		{
			Color c = GetColor();
			switch (colorChannel)
			{
				case (ColorChannel.A):
					return c.a;
				case (ColorChannel.R):
					return c.r;
				case (ColorChannel.G):
					return c.g;
				case (ColorChannel.B):
					return c.b;
				default:
					throw new NotImplementedException("No case found for " + colorChannel);
			}
		}

		public override void SetValue(float f)
		{
			Color c = GetColor();
			switch (colorChannel)
			{
				case (ColorChannel.A):
					c.a = f;
					break;
				case (ColorChannel.R):
					c.r = f;
					break;
				case (ColorChannel.G):
					c.g = f;
					break;
				case (ColorChannel.B):
					c.b = f;
					break;
				default:
					throw new NotImplementedException("No case found for " + colorChannel);
			}
			SetColor(c);
		}
	}
}
