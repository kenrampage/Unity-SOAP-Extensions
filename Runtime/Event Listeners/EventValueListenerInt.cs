using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Int")]
    public class EventValueListenerInt : EventValueListenerGeneric<int>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<int>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<int>.EventValueResponse
        {
            [SerializeField] private ScriptableEventInt _scriptableEvent = null;
            public override ScriptableEvent<int> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<int>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<int>.ValueResponse
        {
            [SerializeField] private int _value;
            public override int Value => _value;

            [SerializeField] private IntUnityEvent _response = null;
            public override UnityEvent<int> Response => _response;
        }

        [System.Serializable]
        public class IntUnityEvent : UnityEvent<int>
        {
        }
    }
}
