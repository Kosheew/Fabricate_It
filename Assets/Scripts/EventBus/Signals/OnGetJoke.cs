using UnityEngine;

namespace CustomEventBus.Signals
{ 
    public class OnGetJoke
    {
        public readonly string Value;

        public OnGetJoke(string value)
        {
            Value = value;
        }
    }
}