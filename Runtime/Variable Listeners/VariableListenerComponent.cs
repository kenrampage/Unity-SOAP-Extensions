using UnityEngine;
using UnityEngine.Events;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Listeners
{
    /// <summary>
    /// A listener for a ComponentVariable.
    /// </summary>
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Listeners/Variable Listener Component")]
    public class VariableListenerComponent : VariableListenerGeneric<Component>
    {
        [Tooltip("Variable-response entries to subscribe and invoke.")]
        [SerializeField] private VariableResponse[] _variableResponses;
        protected override VariableListenerGeneric<Component>.VariableResponse[] VariableResponses => _variableResponses;

        [System.Serializable]
        public new class VariableResponse : VariableListenerGeneric<Component>.VariableResponse
        {
            [Tooltip("Variable asset source for this response entry.")]
            [SerializeField] private ComponentVariable _variable;
            public override ScriptableVariable<Component> Variable => _variable;

            [Tooltip("UnityEvent invoked when this variable changes.")]
            [SerializeField] private ComponentUnityEvent _response;
            public override UnityEvent<Component> Response => _response;
        }

        [System.Serializable]
        public class ComponentUnityEvent : UnityEvent<Component> { }
    }
}
