
using ollyisonit.UnityAccessors;
using org.ollyisonit.mariuszgromada.math.mxparser;

namespace ollyisonit.UnityAnimationModifiers
{

	/// <summary>
	/// Gets argument for mxparser using an Accessor.
	/// </summary>
	public class AccessorArgument : ArgumentExtension
	{
		private Accessor<float> acc;

		public AccessorArgument(Accessor<float> accessor)
		{
			this.acc = accessor;
		}

		public ArgumentExtension clone()
		{
			return new AccessorArgument(acc);
		}

		public double getArgumentValue()
		{
			return acc.Value;
		}
	}
}
