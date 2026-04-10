using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener String")]
    public class EventValueListenerString : EventValueListenerGeneric<string>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<string>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<string>.EventValueResponse
        {
            [SerializeField] private ScriptableEventString _scriptableEvent = null;
            public override ScriptableEvent<string> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<string>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<string>.ValueResponse
        {
            [SerializeField] private string _value;
            public override string Value => _value;

            [SerializeField] private StringUnityEvent _response = null;
            public override UnityEvent<string> Response => _response;
        }

        [System.Serializable]
        public class StringUnityEvent : UnityEvent<string>
        {
        }
    }
}
