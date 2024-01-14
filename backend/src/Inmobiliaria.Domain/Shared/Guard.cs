using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Inmobiliaria.Domain.Shared.Resources;

namespace Inmobiliaria.Domain.Shared;

public static class Guard
{
    /// <summary>
    /// throws an exception if the specified input is null
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <typeparam name="T">the type of the input parameter</typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is null</exception>
    public static T NotNull<T>([NotNull] this T? input, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
    {
        if (input is null)
        {
            throw new ArgumentNullException(paramName, message ?? Errores.ValueCannotBeNull);
        }

        return input;
    }

    /// <summary>
    /// throws an exception if the specified input is not greater than a provided value
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="other">the value to compare with the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <typeparam name="T">the type of the input parameter</typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is not greater than <paramref name="other"/></exception>
    public static T GreaterThan<T>(this T input, T other, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
        where T : IComparable<T>
    {
        if (input.CompareTo(other) <= 0)
        {
            throw new ArgumentException(message ?? string.Format(Errores.ValueMustBeGreaterThan, input, other), paramName);
        }

        return input;
    }

    /// <summary>
    /// throws an exception if the specified input is not greater than or equal to a provided value
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="other">the value to compare with the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <typeparam name="T">the type of the input parameter</typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is not greater than or equal to <paramref name="other"/></exception>
    public static T GreaterOrEqualTo<T>(this T input, T other, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
        where T : IComparable<T>
    {
        if (input.CompareTo(other) < 0)
        {
            throw new ArgumentException(message ?? string.Format(Errores.ValueMustBeGreaterOrEqualTo, input, other), paramName);
        }

        return input;
    }

    /// <summary>
    /// throws an exception if the specified input is not less than a provided value
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="other">the value to compare with the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <typeparam name="T">the type of the input parameter</typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is not less than <paramref name="other"/></exception>
    public static T LessThan<T>(this T input, T other, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
        where T : IComparable<T>
    {
        if (input.CompareTo(other) >= 0)
        {
            throw new ArgumentException(message ?? string.Format(Errores.ValueMustBeLessThan, input, other), paramName);
        }

        return input;
    }

    /// <summary>
    /// throws an exception if the specified input is not less than or equal to a provided value
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="other">the value to compare with the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <typeparam name="T">the type of the input parameter</typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is not less than or equal to <paramref name="other"/></exception>
    public static T LessOrEqualTo<T>(this T input, T other, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
        where T : IComparable<T>
    {
        if (input.CompareTo(other) > 0)
        {
            throw new ArgumentException(message ?? string.Format(Errores.ValueMustBeLessOrEqualTo, input, other), paramName);
        }

        return input;
    }

    /// <summary>
    /// throws an exception if the specified input is empty
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is empty</exception>
    public static string NotNullOrEmpty([NotNull] this string? input, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException(message ?? Errores.ValueMustNotBeEmpty, paramName);
        }

        return input;
    }

    /// <summary>
    /// throws an exception if the specified input is empty
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is empty</exception>
    public static Guid NotEmpty(this Guid input, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
    {
        if (input == Guid.Empty)
        {
            throw new ArgumentException(message ?? Errores.ValueMustNotBeEmpty, paramName);
        }

        return input;
    }

    /// <summary>
    /// throws an exception if the specified input is whitespace
    /// </summary>
    /// <param name="input">the input</param>
    /// <param name="message">custom message for the exception</param>
    /// <param name="paramName">the name of the input parameter</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">thrown when <paramref name="input"/> is whitespace</exception>
    public static string NotNullOrWhiteSpace([NotNull] this string? input, string? message = default,
        [CallerArgumentExpression(nameof(input))] string? paramName = default)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(message ?? Errores.ValueMustNotBeEmpty, paramName);
        }

        return input;
    }
}
