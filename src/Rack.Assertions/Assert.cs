using System;

namespace Rack.Assertions
{
    /// <summary>
    /// Provides methods to assert conditions.
    /// </summary>
    public static class Assert
    {
        /// <summary>
        /// Provides methods that assert conditions on method parameters.
        /// </summary>
        public static readonly ParameterAssertions Parameter = new ParameterAssertions();
    }
}
