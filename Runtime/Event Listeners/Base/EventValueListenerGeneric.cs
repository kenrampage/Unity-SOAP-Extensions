using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    public abstract class EventValueListenerGeneric<TValue> : EventListenerGeneric<TValue>
    {
        protected abstract EventValueResponse[] EventValueResponses { get; }
        protected override EventResponse<TValue>[] EventResponses => EventValueResponses;

        protected virtual bool IsMatch(TValue expected, TValue current)
        {
            return EqualityComparer<TValue>.Default.Equals(expected, current);
        }

        protected override void InvokeResponse(ScriptableEvent<TValue> eventRaised, EventResponse<TValue> eventResponse, TValue param, bool debug)
        {
            if (eventResponse is not EventValueResponse valueEventResponse)
                return;

            var didInvoke = false;
            var valueResponses = valueEventResponse.ValueResponses;
            if (valueResponses == null)
                return;

            foreach (var valueResponse in valueResponses)
            {
                if (valueResponse == null)
                    continue;

                if (!IsMatch(valueResponse.Value, param))
                    continue;

                valueResponse.Response?.Invoke(param);
                didInvoke = true;
            }

            if (didInvoke && debug)
                Debug(eventRaised);
        }

        public override bool ContainsCallToMethod(string methodName)
        {
            var containsMethod = false;
            foreach (var eventResponse in EventValueResponses)
            {
                var valueResponses = eventResponse.ValueResponses;
                if (valueResponses == null)
                    continue;

                foreach (var valueResponse in valueResponses)
                {
                    if (valueResponse?.Response == null)
                        continue;

                    var registeredListenerCount = valueResponse.Response.GetPersistentEventCount();
                    for (var i = 0; i < registeredListenerCount; i++)
                    {
                        if (valueResponse.Response.GetPersistentMethodName(i) == methodName)
                        {
                            var sb = new StringBuilder();
                            sb.Append($"<color=#f75369>{methodName}()</color>");
                            sb.Append(" is called by: <color=#f75369>[Event Value] </color>");
                            sb.Append(eventResponse.ScriptableEvent.name);
                            UnityEngine.Debug.Log(sb.ToString(), gameObject);
                            containsMethod = true;
                            break;
                        }
                    }
                }
            }

            return containsMethod;
        }

        [Serializable]
        public class EventValueResponse : EventResponse<TValue>
        {
            public override ScriptableEvent<TValue> ScriptableEvent { get; }
            public virtual ValueResponse[] ValueResponses { get; }
        }

        [Serializable]
        public class ValueResponse
        {
            public virtual TValue Value { get; }
            public virtual UnityEvent<TValue> Response { get; }
        }
    }
}
