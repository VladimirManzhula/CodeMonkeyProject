using Core.Constants;
using Core.Services.OpenWindow;
using Databases.Keyboard;
using Databases.Players;
using Game.DataHolders;
using Game.Services.InteractObjects;
using SimpleUi.Signals;
using Ui.Game.Windows;
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
        private readonly IOpenWindowService _openWindowService;
        private readonly SignalBus _signalBus;
        private bool _isActiveInput;

        public InputManager(
            IKeyboardDatabase keyboardDatabase,
            IPlayerModelDataHolder playerModelDataHolder,
            IPlayerSettingBase playerSettingBase,
            IInteractObjectService interactObjectService,
            IOpenWindowService openWindowService,
            SignalBus signalBus
        )
        {
            _keyboardDatabase = keyboardDatabase;
            _playerModelDataHolder = playerModelDataHolder;
            _playerSettingBase = playerSettingBase;
            _interactObjectService = interactObjectService;
            _openWindowService = openWindowService;
            _signalBus = signalBus;
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
            PressGameMenu();
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

        private void PressGameMenu()
        {
            PressPause();
        }

        private void PressPause()
        {
            if (!IsKeyDown(_keyboardDatabase.Pause))
                return;
            
            var isPauseWindowOpen = _openWindowService.IsWindowCurrentlyOpen(WindowNames.EGameType.Pause);
            
            if (isPauseWindowOpen)
                return;
            
            _signalBus.OpenWindow<PauseWindow>();
        }

        private static bool IsKey(KeyCode code) => Input.GetKey(code);

        private static bool IsKeyDown(KeyCode code) => Input.GetKeyDown(code);

        private static bool IsKeyUp(KeyCode code) => Input.GetKeyUp(code);
    }
}