using UnityEngine;

namespace Game.Views
{
    public class LocationView : MonoBehaviour
    {
        [SerializeField] Transform location;
        
        public Transform Location => location;
    }
}