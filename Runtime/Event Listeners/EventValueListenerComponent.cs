using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Component")]
    public class EventValueListenerComponent : EventValueListenerGeneric<Component>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<Component>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<Component>.EventValueResponse
        {
            [SerializeField] private ScriptableEventComponent _scriptableEvent = null;
            public override ScriptableEvent<Component> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<Component>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<Component>.ValueResponse
        {
            [SerializeField] private Component _value;
            public override Component Value => _value;

            [SerializeField] private ComponentUnityEvent _response = null;
            public override UnityEvent<Component> Response => _response;
        }

        [System.Serializable]
        public class ComponentUnityEvent : UnityEvent<Component>
        {
        }
    }
}
