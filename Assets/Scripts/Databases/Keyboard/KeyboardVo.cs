using System;
using UnityEngine;

namespace Databases.Keyboard
{
    [Serializable]
    public class KeyboardVo
    {
        [Header("Control")]
        public KeyCode interact;
        public KeyCode interactAlternative;
        
        [Header("Move")]
        public KeyCode moveForward;
        public KeyCode moveBack;
        public KeyCode moveLeft;
        public KeyCode moveRight;
        
        [Header("Menu")]
        public KeyCode pause;
    }
}