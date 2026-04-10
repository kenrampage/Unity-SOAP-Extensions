using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Quaternion")]
    public class EventValueListenerQuaternion : EventValueListenerGeneric<Quaternion>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<Quaternion>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<Quaternion>.EventValueResponse
        {
            [SerializeField] private ScriptableEventQuaternion _scriptableEvent = null;
            public override ScriptableEvent<Quaternion> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<Quaternion>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<Quaternion>.ValueResponse
        {
            [SerializeField] private Quaternion _value;
            public override Quaternion Value => _value;

            [SerializeField] private QuaternionUnityEvent _response = null;
            public override UnityEvent<Quaternion> Response => _response;
        }

        [System.Serializable]
        public class QuaternionUnityEvent : UnityEvent<Quaternion>
        {
        }
    }
}
