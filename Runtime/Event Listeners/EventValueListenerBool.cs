using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Bool")]
    public class EventValueListenerBool : EventValueListenerGeneric<bool>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<bool>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<bool>.EventValueResponse
        {
            [SerializeField] private ScriptableEventBool _scriptableEvent = null;
            public override ScriptableEvent<bool> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<bool>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<bool>.ValueResponse
        {
            [SerializeField] private bool _value;
            public override bool Value => _value;

            [SerializeField] private BoolUnityEvent _response = null;
            public override UnityEvent<bool> Response => _response;
        }

        [System.Serializable]
        public class BoolUnityEvent : UnityEvent<bool>
        {
        }
    }
}
