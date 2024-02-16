using System;

namespace SoftlineTestTaskApp.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType, string parameterName)
            : base($"'{entityType.Name}' with the specified parameter '{parameterName}' was not found.")
        {
        }
    }
}