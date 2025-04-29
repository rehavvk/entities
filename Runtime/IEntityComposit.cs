using System;
using Rehawk.Foundation.Misc;
using UnityEngine;

namespace Rehawk.Entities
{
    public interface IEntityComposit
    {
        public event Action<IEntityComposit> Activated;
        public event Action<IEntityComposit> Deactivated;
        
        Entity Entity { get; }
        EntityDefinition Definition { get; }

        void Despawn();
        void SetState(EntityCompositStateBase state);
        EntityCompositStateBase GetState();
    }
}