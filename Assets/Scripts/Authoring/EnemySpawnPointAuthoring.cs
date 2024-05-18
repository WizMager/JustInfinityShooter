using Components;
using Unity.Entities;
using UnityEngine;

namespace Authoring
{
    public class EnemySpawnPointAuthoring : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnCooldown;
        
        private class MonsterSpawnPointAuthoringBaker : Baker<EnemySpawnPointAuthoring>
        {
            public override void Bake(EnemySpawnPointAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new EnemyPrefab
                {
                    Enemy = GetEntity(authoring.enemyPrefab, TransformUsageFlags.Dynamic)
                });
                AddComponent(entity, new SpawnCooldown
                {
                    Value = authoring.spawnCooldown
                });
            }
        }
    }
}