using Databases.Keyboard;
using Databases.Players;
using Game.DataHolders;
using Game.Services.InteractObjects;
using UnityEngine;
using Zenject;

namespace Core.Inputs.Impls
{
    public class InputManager : IInputManager, ITickable
    {
        private readonly IKeyboardDatabase _keyboardDatabase;
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IPlayerSettingBase _playerSettingBase;
        private readonly IInteractObjectService _interactObjectService;

        public InputManager(
            IKeyboardDatabase keyboardDatabase,
            IPlayerModelDataHolder playerModelDataHolder,
            IPlayerSettingBase playerSettingBase,
            IInteractObjectService interactObjectService
        )
        {
            _keyboardDatabase = keyboardDatabase;
            _playerModelDataHolder = playerModelDataHolder;
            _playerSettingBase = playerSettingBase;
            _interactObjectService = interactObjectService;
        }

        public void Tick()
        {
            /*if (!IsActiveInput)
                return;*/
            
            ProcessMovement();
            ProcessInteract();
        }

        private void ProcessMovement()
        {
            var velocity = Vector3.zero;
            if (Input.GetKey(_keyboardDatabase.MoveForward))
                velocity.z += 1;
            if (Input.GetKey(_keyboardDatabase.MoveBack))
                velocity.z -= 1;
            if (Input.GetKey(_keyboardDatabase.MoveRight))
                velocity.x += 1;
            if (Input.GetKey(_keyboardDatabase.MoveLeft))
                velocity.x -= 1;

            velocity = velocity.normalized * _playerSettingBase.Velocity;

            _playerModelDataHolder.Model.SetVelocityDirection = velocity;
        }

        private void ProcessInteract()
        {
            if (Input.GetKey(_keyboardDatabase.Interact))
                _interactObjectService.Execute();
        }
    }
}