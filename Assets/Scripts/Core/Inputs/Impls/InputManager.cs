using Databases.Keyboard;
using Databases.Players;
using Game.DataHolders;
using Game.Services.InteractObjects;
using UnityEngine;
using Zenject;

namespace Core.Inputs.Impls
{
    public class InputManager : IInputManager, IInitializable, ITickable
    {
        private readonly IKeyboardDatabase _keyboardDatabase;
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IPlayerSettingBase _playerSettingBase;
        private readonly IInteractObjectService _interactObjectService;
        private bool _isActiveInput;

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

        public bool IsActiveInput
        {
            get => _isActiveInput;
            set => _isActiveInput = value;
        }

        public void Initialize()
        {
            _isActiveInput = false;
        }

        public void Tick()
        {
            if (!_isActiveInput)
                return;
            
            ProcessMovement();
            ProcessInteract();
            ProcessInteractAlternative();
        }

        private void ProcessMovement()
        {
            var velocity = Vector3.zero;
            if (IsKey(_keyboardDatabase.MoveForward))
                velocity.z += 1;
            if (IsKey(_keyboardDatabase.MoveBack))
                velocity.z -= 1;
            if (IsKey(_keyboardDatabase.MoveRight))
                velocity.x += 1;
            if (IsKey(_keyboardDatabase.MoveLeft))
                velocity.x -= 1;

            velocity = velocity.normalized * _playerSettingBase.Velocity;

            _playerModelDataHolder.Model.SetVelocityDirection = velocity;
        }

        private void ProcessInteract()
        {
            if (!IsKeyDown(_keyboardDatabase.Interact))
                return;
                
            _interactObjectService.Execute();
        }

        private void ProcessInteractAlternative()
        {
            if (!IsKeyDown(_keyboardDatabase.InteractAlternative))
                return;
                
            _interactObjectService.ExecuteAlternative();
        }

        private static bool IsKey(KeyCode code) => Input.GetKey(code);

        private static bool IsKeyDown(KeyCode code) => Input.GetKeyDown(code);

        private static bool IsKeyUp(KeyCode code) => Input.GetKeyUp(code);
    }
}