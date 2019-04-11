using System;

namespace EVEStandard
{
    internal class EVEStandardException : Exception
    {
        internal EVEStandardException()
        {
        }

        internal EVEStandardException(string message)
            : base(message)
        {
        }

        internal EVEStandardException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    internal class EVEStandardAuthExpiredException : EVEStandardException
    {
    }

    internal class EVEStandardScopeNotAcquired : EVEStandardException
    {
        internal EVEStandardScopeNotAcquired()
        {
        }

        internal EVEStandardScopeNotAcquired(string message)
            : base(message)
        {
        }
    }

    internal class EVEStandardUnauthorizedException : EVEStandardException
    {
    }
}
