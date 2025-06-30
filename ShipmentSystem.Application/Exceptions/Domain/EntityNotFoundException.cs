﻿namespace ShipmentSystem.Application.Exceptions.Domain;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entity, object key)
        : base($"{entity} with key '{key}' was not found.") { }
}
