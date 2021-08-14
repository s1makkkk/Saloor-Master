using System.Collections.Generic;

namespace ECS.Components
{
    struct DelayComponent
    {
        public Dictionary<string, DelayTimer> Timers;
    }

    [System.Serializable]
    class DelayTimer
    {
        public float TimeDelay;
        public float Timer;
        public bool TimeOut;
    }
}