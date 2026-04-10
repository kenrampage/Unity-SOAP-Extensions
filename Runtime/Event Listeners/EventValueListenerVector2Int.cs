using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener Vector2Int")]
    public class EventValueListenerVector2Int : EventValueListenerGeneric<Vector2Int>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<Vector2Int>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<Vector2Int>.EventValueResponse
        {
            [SerializeField] private ScriptableEventVector2Int _scriptableEvent = null;
            public override ScriptableEvent<Vector2Int> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<Vector2Int>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<Vector2Int>.ValueResponse
        {
            [SerializeField] private Vector2Int _value;
            public override Vector2Int Value => _value;

            [SerializeField] private Vector2IntUnityEvent _response = null;
            public override UnityEvent<Vector2Int> Response => _response;
        }

        [System.Serializable]
        public class Vector2IntUnityEvent : UnityEvent<Vector2Int>
        {
        }
    }
}
