using System;

namespace Rack.Assertions
{
    /// <summary>
    /// Provides methods that assert conditions on method parameters.
    /// </summary>
    public class ParameterAssertions
    {
        /// <summary>
        /// Asserts that a parameter value satisfies an arbitrary assertion.
        /// </summary>
        /// <param name="assertion">If false, then an argument exception will be thrown.</param>
        /// <param name="message">The message to throw as part of the assertion.</param>
        /// <param name="parameterName">The parameter name.</param>
        public void Is(bool assertion, string message, string parameterName)
        {
            if (!assertion)
            {
                throw new ArgumentException(message, parameterName);
            }
        }

        /// <summary>
        /// Asserts that a parameter value is not <c>null</c>.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public void IsNotNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Asserts that a string parameter value is not <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public void IsNotNullOrEmpty(string value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Parameter must not be an empty string", parameterName);
            }
        }

        /// <summary>
        /// Asserts that a parameter value is equal to or greater than 0.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public void IsNotNegative(int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, "Parameter must be greater than or equal to 0");
            }
        }

        /// <summary>
        /// Asserts that a parameter value is equal to or greater than 0.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public void IsNotNegative(long value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, "Parameter must be greater than or equal to 0");
            }
        }

        /// <summary>
        /// Asserts that a parameter value is equal to or greater than 0.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public void IsNotNegative(TimeSpan value, string parameterName)
        {
            if (value < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, "Parameter must be greater than or equal to 0");
            }
        }

        /// <summary>
        /// Asserts that a parameter is greater than a value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="otherValue">The value to test against.</param>
        /// <param name="parameterName">The parameter name.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsGreaterThan<T>(T parameterValue, T otherValue, string parameterName) where T : IComparable<T>
        {
            if (parameterValue.CompareTo(otherValue) <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, parameterValue, $"Parameter must be greater than {otherValue}");
            }
        }

        /// <summary>
        /// Asserts that a parameter is greater than or equal to a value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="otherValue">The value to test against.</param>
        /// <param name="parameterName">The parameter name.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsGreaterThanOrEqualTo<T>(T parameterValue, T otherValue, string parameterName) where T : IComparable<T>
        {
            if (parameterValue.CompareTo(otherValue) < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, parameterValue, $"Parameter must be greater than or equal to {otherValue}");
            }
        }

        /// <summary>
        /// Asserts that a parameter is less than a value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="otherValue">The value to test against.</param>
        /// <param name="parameterName">The parameter name.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsLessThan<T>(T parameterValue, T otherValue, string parameterName) where T : IComparable<T>
        {
            if (parameterValue.CompareTo(otherValue) >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, parameterValue, $"Parameter must be less than {otherValue}");
            }
        }

        /// <summary>
        /// Asserts that a parameter is less than or equal to a value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="otherValue">The value to test against.</param>
        /// <param name="parameterName">The parameter name.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void IsLessThanOrEqualTo<T>(T parameterValue, T otherValue, string parameterName) where T : IComparable<T>
        {
            if (parameterValue.CompareTo(otherValue) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, parameterValue, $"Parameter must be less than or equal to {otherValue}");
            }
        }


        /// <summary>
        /// Asserts that a parameter is within a range (inclusive of the low and high bounds).
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="lowBound">The low bound (inclusive).</param>
        /// <param name="highBound">The high bound (inclusive).</param>
        /// <param name="parameterName">The parameter name.</param>
        public void IsWithinRange<T>(T value, T lowBound, T highBound, string parameterName) where T : IComparable<T>
        {
            if (value.CompareTo(lowBound) < 0 || value.CompareTo(highBound) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, $"Parameter must be a value between {lowBound} and {highBound}");
            }
        }

        /// <summary>
        /// Asserts that a parameter is a valid index for a given count or length of collection.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="count">The maximum count.</param>
        /// <param name="parameterName">The parameter name.</param>
        public void IsIndexInRage(int value, int count, string parameterName)
        {
            if (value < 0 || value >= count)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, $"Index was out of range. Must be non-negative and less than {count}.");
            }
        }
    }
}