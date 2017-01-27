namespace NETStandard.Library.Extensions
{
    using System;

    /// <summary>
    /// Defines a helper class that provides extension methods over <see cref="string" /> type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is null or an <see cref="string.Empty" /> string.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>
        /// true if the value parameter is null or <see cref="string.Empty" />, or if value consists exclusively of
        /// white-space characters.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Gets name of controller by given controller type. For example: HomeController -> Home.
        /// </summary>
        /// <param name="value">The string represents the controller name.</param>
        /// <returns>The controller name.</returns>
        public static string GetControllerName(this string value) => !value.IsNullOrWhiteSpace() ? value.Replace("Controller", string.Empty) : string.Empty;

        /// <summary>
        /// Get string between given startString and endString values starting from specified index.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <param name="startString">The start string.</param>
        /// <param name="endString">The end string.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>Returns the value between startString and endString, or empty string if there is no value.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startIndex = 0)
        {
            input = input.Substring(startIndex);
            startIndex = 0;

            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startIndex, StringComparison.OrdinalIgnoreCase) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.OrdinalIgnoreCase);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }
    }
}