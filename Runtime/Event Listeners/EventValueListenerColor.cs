using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Color")]
    public class EventValueListenerColor : EventValueListenerGeneric<Color>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<Color>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<Color>.EventValueResponse
        {
            [SerializeField] private ScriptableEventColor _scriptableEvent = null;
            public override ScriptableEvent<Color> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<Color>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<Color>.ValueResponse
        {
            [SerializeField] private Color _value;
            public override Color Value => _value;

            [SerializeField] private ColorUnityEvent _response = null;
            public override UnityEvent<Color> Response => _response;
        }

        [System.Serializable]
        public class ColorUnityEvent : UnityEvent<Color>
        {
        }
    }
}
