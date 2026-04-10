using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Vector2")]
    public class EventValueListenerVector2 : EventValueListenerGeneric<Vector2>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<Vector2>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<Vector2>.EventValueResponse
        {
            [SerializeField] private ScriptableEventVector2 _scriptableEvent = null;
            public override ScriptableEvent<Vector2> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<Vector2>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<Vector2>.ValueResponse
        {
            [SerializeField] private Vector2 _value;
            public override Vector2 Value => _value;

            [SerializeField] private Vector2UnityEvent _response = null;
            public override UnityEvent<Vector2> Response => _response;
        }

        [System.Serializable]
        public class Vector2UnityEvent : UnityEvent<Vector2>
        {
        }
    }
}
