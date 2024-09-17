using UnityEngine;

namespace Core.Providers.Impls
{
    public class TimeProvider : ITimeProvider
    {
        public float DeltaTime => Time.deltaTime;
        
        public float TimeScale
        {
            get => Time.timeScale;
            set => Time.timeScale = value;
        }
    }
}