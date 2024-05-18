using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class GetPlayerInputSystem : SystemBase
    {
        private InputActions _inputActions;
        private Entity _playerEntity;

        protected override void OnCreate()
        {
            RequireForUpdate<PlayerTag>();
            RequireForUpdate<PlayerMoveInput>();

            _inputActions = new InputActions();
        }

        protected override void OnStartRunning()
        {
            _inputActions.Enable();

            _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
        }

        protected override void OnUpdate()
        {
            var currentMoveInput = _inputActions.MouseAndKeyboard.Move.ReadValue<Vector2>();
            
            SystemAPI.SetSingleton(new PlayerMoveInput
            {
                Value = currentMoveInput
            });
        }

        protected override void OnStopRunning()
        {
            _inputActions.Disable();
            
            _playerEntity = Entity.Null;
        }
    }
}