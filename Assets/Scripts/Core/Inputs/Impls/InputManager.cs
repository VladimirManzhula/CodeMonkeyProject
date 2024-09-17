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
        private readonly IKeyboardBase _keyboardBase;
        private readonly IPlayerModelDataHolder _playerModelDataHolder;
        private readonly IPlayerSettingBase _playerSettingBase;
        private readonly IInteractObjectService _interactObjectService;
        private readonly IOpenWindowService _openWindowService;
        private readonly SignalBus _signalBus;
        private bool _isActiveInput;

        public InputManager(
            IKeyboardBase keyboardBase,
            IPlayerModelDataHolder playerModelDataHolder,
            IPlayerSettingBase playerSettingBase,
            IInteractObjectService interactObjectService,
            IOpenWindowService openWindowService,
            SignalBus signalBus
        )
        {
            _keyboardBase = keyboardBase;
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
            if (IsKey(_keyboardBase.KeyboardVo.moveForward))
                velocity.z += 1;
            if (IsKey(_keyboardBase.KeyboardVo.moveBack))
                velocity.z -= 1;
            if (IsKey(_keyboardBase.KeyboardVo.moveRight))
                velocity.x += 1;
            if (IsKey(_keyboardBase.KeyboardVo.moveLeft))
                velocity.x -= 1;

            velocity = velocity.normalized * _playerSettingBase.Velocity;

            _playerModelDataHolder.Model.SetVelocityDirection = velocity;
        }

        private void ProcessInteract()
        {
            if (!IsKeyDown(_keyboardBase.KeyboardVo.interact))
                return;
                
            _interactObjectService.Execute();
        }

        private void ProcessInteractAlternative()
        {
            if (!IsKeyDown(_keyboardBase.KeyboardVo.interactAlternative))
                return;
                
            _interactObjectService.ExecuteAlternative();
        }

        private void PressGameMenu()
        {
            PressPause();
        }

        private void PressPause()
        {
            if (!IsKeyDown(_keyboardBase.KeyboardVo.pause))
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