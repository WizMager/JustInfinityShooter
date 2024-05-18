using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct PlayerMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            new PlayerMoveJob
            {
                DeltaTime = deltaTime
            }.Schedule();
        }

        [BurstCompile]
        public partial struct PlayerMoveJob : IJobEntity
        {
            public float DeltaTime;
            
            [BurstCompile]
            public void Execute(ref LocalTransform transform, in PlayerMoveInput moveInput, PlayerMoveSpeed speed)
            {
                transform.Position.xz += moveInput.Value * DeltaTime * speed.Value;
            }
        }
    }
}