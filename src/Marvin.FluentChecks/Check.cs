using Marvin.FluentChecks.Extensions;
using System;
using System.Linq.Expressions;

namespace Marvin.FluentChecks
{
    /// <summary>
    /// Checks can be both business and contract, contract checks return
    /// exceptions to be thrown business checks return CheckResults
    /// </summary>
    public interface ICheck
    {
        bool Passed { get; }

        IEnumerable<string> Errors { get; }

        IEnumerable<Exception> Exceptions { get; }

        void AddError(string error);

        void AddException(Exception ex);

        ICheck ContractRule(Func<bool> func, Exception ex);

        ICheck BusinessRule(Func<bool> func, string error);
    }

    /// <inheritdoc />
    public sealed class Check : ICheck
    {
        private readonly List<string> _errors = new(1);
        private readonly List<Exception> _exceptions = new(1);

        private Check() { }

        /// <inheritdoc />
        public bool Passed => !(_errors.Any() || _exceptions.Any());

        /// <inheritdoc />
        public IEnumerable<string> Errors => _errors;

        /// <inheritdoc />
        public IEnumerable<Exception> Exceptions => _exceptions;

        /// <inheritdoc />
        public void AddError(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                return;
            }
            lock (_exceptions)
            {
                _errors.Add(error);
            }
        }

        /// <inheritdoc />
        public void AddException(Exception ex)
        {
            if (ex.IsNull())
            {
                return;
            }
            lock (_exceptions)
            {
                _exceptions.Add(ex);
            }
        }

        /// <inheritdoc />
        public ICheck ContractRule(Func<bool> func, Exception ex)
        {
            if (func.IsNull() || ex.IsNull())
            {
                return this;
            }

            if (func.Invoke())
            {
                AddException(ex);
            }
            return this;
        }

        /// <inheritdoc />
        public ICheck BusinessRule(Func<bool> func, string error)
        {
            if (func.IsNull() || string.IsNullOrWhiteSpace(error))
            {
                return this;
            }

<<<<<<< HEAD
            if (func())
=======
            if (func.Invoke())
>>>>>>> main
            {
                AddError(error);
            }
            return this;
        }

        public static ICheck Start() => new Check();

        public static ICheck Contract(Func<bool> func, Exception ex) => Start().ContractRule(func, ex);

        public static ICheck ArgNullContract<T>(Expression<Func<T>> func) => Start().ArgNullContract(func);

        public static ICheck Business(Func<bool> func, string error) => Start().BusinessRule(func, error);
    }
}
