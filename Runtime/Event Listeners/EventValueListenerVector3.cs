using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Vector3")]
    public class EventValueListenerVector3 : EventValueListenerGeneric<Vector3>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<Vector3>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<Vector3>.EventValueResponse
        {
            [SerializeField] private ScriptableEventVector3 _scriptableEvent = null;
            public override ScriptableEvent<Vector3> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<Vector3>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<Vector3>.ValueResponse
        {
            [SerializeField] private Vector3 _value;
            public override Vector3 Value => _value;

            [SerializeField] private Vector3UnityEvent _response = null;
            public override UnityEvent<Vector3> Response => _response;
        }

        [System.Serializable]
        public class Vector3UnityEvent : UnityEvent<Vector3>
        {
        }
    }
}
