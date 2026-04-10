using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Float")]
    public class EventValueListenerFloat : EventValueListenerGeneric<float>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<float>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<float>.EventValueResponse
        {
            [SerializeField] private ScriptableEventFloat _scriptableEvent = null;
            public override ScriptableEvent<float> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<float>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<float>.ValueResponse
        {
            [SerializeField] private float _value;
            public override float Value => _value;

            [SerializeField] private FloatUnityEvent _response = null;
            public override UnityEvent<float> Response => _response;
        }

        [System.Serializable]
        public class FloatUnityEvent : UnityEvent<float>
        {
        }
    }
}
