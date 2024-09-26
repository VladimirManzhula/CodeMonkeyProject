using Core.Utils.DAO;
using Databases.Keyboard;
using UnityEngine;
using Zenject;

namespace Game.Services.DAO.Settings.Impls
{
    public class SettingsState : APersistenceState<ISettingsDao, SettingsVo>, ISettingsState, IInitializable
    {
        private SettingsVo _vo;
        
        public SettingsState(ISettingsDao dao) : base(dao)
        {
        }

        public void Initialize()
        {
            if (!Dao.Exist())
            {
                _vo = new SettingsVo
                {
                    keyboardVo = new KeyboardVo
                    {
                        interact = KeyCode.E,
                        interactAlternative = KeyCode.F,
                        moveForward = KeyCode.W,
                        moveBack = KeyCode.S,
                        moveLeft = KeyCode.A,
                        moveRight = KeyCode.D,
                        pause = KeyCode.Escape,
                    },
                    
                    audioSettingsVo = new AudioSettingsVo {isMusic = true, isSound = true}
                };

                SetDirty();
                return;
            }
            
            _vo = Dao.Load();
        }

        public KeyboardVo KeyboardVo => _vo.keyboardVo;
        
        public AudioSettingsVo GetAudioSettings() => _vo.audioSettingsVo;

        public void SetAudioMusicSettings()
        {
            _vo.audioSettingsVo.isMusic = !_vo.audioSettingsVo.isMusic;
            SetDirty();
        }
        
        public void SetAudioSoundSettings()
        {
            _vo.audioSettingsVo.isSound = !_vo.audioSettingsVo.isSound;
            SetDirty();
        }
        
        protected override SettingsVo ConvertToState() => _vo;
    }
}