using UnityEngine;
using UnityEngine.UI;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	[System.Serializable]
	public class ImageColorFloatValueAccessor : ColorFloatValueAccessor
	{
		public Image image;
		protected override Color GetColor()
		{
			return image.color;
		}

		protected override void SetColor(Color c)
		{
			image.color = c;
		}
	}
}
