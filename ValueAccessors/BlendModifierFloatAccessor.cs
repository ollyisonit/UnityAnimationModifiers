using dninosores.UnityAccessors;

namespace dninosores.UnityAnimationModifiers.Accessors
{
	public class BlendModifierFloatAccessor : CustomFloatAccessor
	{
		private float stored;

		public override float GetValue()
		{
			return stored;
		}

		public override void SetValue(float value)
		{
			stored = value;
		}
	}
}
