using System;

namespace SoftlineTestTaskApp.Domain.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(Type entityType) : base($"'{entityType.Name}' is already exists.")
        {
        }

        public EntityAlreadyExistsException(Type entityType, string parameterName) 
            : base($"'{entityType.Name}' with specified '{parameterName}' is already exists.")
        {
        }
    }
}