using Core.Utils.DAO;
using Databases.Keyboard;
using Databases.Keyboard.Impls;
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
                    }
                };

                SetDirty();
                return;
            }
            
            _vo = Dao.Load();
        }

        public KeyboardVo KeyboardVo => _vo.keyboardVo;
        
        protected override SettingsVo ConvertToState() => _vo;
    }
}