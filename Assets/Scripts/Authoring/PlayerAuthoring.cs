using Components;
using Unity.Entities;
using UnityEngine;

namespace Authoring
{
    public class PlayerAuthoring : MonoBehaviour
    {
        [SerializeField] private float playerMoveSpeed;
        
        private class PlayerAuthoringBaker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent<PlayerTag>(entity);
                AddComponent<PlayerMoveInput>(entity);
                AddComponent(entity, new PlayerMoveSpeed
                {
                    Value = authoring.playerMoveSpeed
                });
            }
        }
    }
}