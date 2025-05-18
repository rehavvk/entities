using System;
using Rehawk.Foundation.Misc;
using UnityEngine;

namespace Rehawk.Entities
{
    public static class EntityFactory
    {
        public static Entity SpawnByDefinition(EntityDefinition definition, Vector3 position, Quaternion rotation)
        {
            return SpawnByState(definition.CreateState(), position, rotation);
        }

        public static T SpawnByDefinition<T>(EntityDefinition definition, Vector3 position, Quaternion rotation)
            where T : Entity
        {
            return (T) SpawnByDefinition(definition, position, rotation);
        }
        
        public static Entity SpawnByState(EntityState state, Vector3 position, Quaternion rotation)
        {
            Entity prefab = null;
            if (ObjectUtility.IsNotNull(state.Definition))
            {
                prefab = state.Definition.Prefab;
            }

            if (prefab == null)
            {
                Debug.LogError(new Exception($"<b>{nameof(EntityFactory)}:</b> No prefab provided."));
            }
            else
            {
                GameObject entityObject = EntitiesInterface.Spawn(prefab.gameObject, position, rotation);
                var entity = entityObject.GetComponent<Entity>();
                entity.SetState(state);

                return entity;
            }
            
            return null;
        }
        
        public static Entity SpawnByState(EntityState state)
        {
            return SpawnByState(state, state.Position, state.Rotation);
        }

        public static T SpawnByState<T>(EntityState state)
            where T : Entity
        {
            return (T) SpawnByState(state, state.Position, state.Rotation);
        }

        public static void Despawn(Entity entity)
        {
            EntitiesInterface.Despawn(entity.gameObject);
        }
    }
}