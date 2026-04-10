using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Event Value Listener GameObject")]
    public class EventValueListenerGameObject : EventValueListenerGeneric<GameObject>
    {
        [SerializeField] private EventValueResponse[] _eventResponses = null;
        protected override EventValueListenerGeneric<GameObject>.EventValueResponse[] EventValueResponses => _eventResponses;

        [System.Serializable]
        public new class EventValueResponse : EventValueListenerGeneric<GameObject>.EventValueResponse
        {
            [SerializeField] private ScriptableEventGameObject _scriptableEvent = null;
            public override ScriptableEvent<GameObject> ScriptableEvent => _scriptableEvent;

            [SerializeField] private ValueResponse[] _valueResponses = null;
            public override EventValueListenerGeneric<GameObject>.ValueResponse[] ValueResponses => _valueResponses;
        }

        [System.Serializable]
        public new class ValueResponse : EventValueListenerGeneric<GameObject>.ValueResponse
        {
            [SerializeField] private GameObject _value;
            public override GameObject Value => _value;

            [SerializeField] private GameObjectUnityEvent _response = null;
            public override UnityEvent<GameObject> Response => _response;
        }

        [System.Serializable]
        public class GameObjectUnityEvent : UnityEvent<GameObject>
        {
        }
    }
}
