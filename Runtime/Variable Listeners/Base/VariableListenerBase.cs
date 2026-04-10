using System.Threading;
using UnityEngine;

namespace KenRampage.Addons.SOAP.Listeners
{
    /// <summary>
    /// Base lifecycle class for listener components in this extensions package.
    /// Controls binding lifetime and optional one-time invocation at subscribe time.
    /// </summary>
    public abstract class VariableListenerBase : MonoBehaviour
    {
        #region Types

        protected enum Binding
        {
            UNTIL_DESTROY,
            UNTIL_DISABLE
        }

        #endregion

        #region Inspector

        [Tooltip("Controls when this listener subscribes and unsubscribes.")]
        [SerializeField] protected Binding _binding = Binding.UNTIL_DESTROY;
        [Tooltip("If enabled, invokes listener responses once immediately after subscribing.")]
        [SerializeField] protected bool _invokeOnSubscribe = false;
        [Tooltip("If enabled, disables this GameObject right after subscription is set up.")]
        [SerializeField] protected bool _disableAfterSubscribing = false;

        #endregion

        #region Runtime

        protected readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        protected abstract void ToggleRegistration(bool toggle);

        /// <summary>
        /// Returns true if this listener contains a call to the method with the given name.
        /// </summary>
        public abstract bool ContainsCallToMethod(string methodName);

        #endregion

        #region Unity Lifecycle

        protected virtual void Awake()
        {
            if (_binding == Binding.UNTIL_DESTROY)
                ToggleRegistration(true);

            gameObject.SetActive(!_disableAfterSubscribing);
        }

        protected virtual void OnEnable()
        {
            if (_binding == Binding.UNTIL_DISABLE)
                ToggleRegistration(true);
        }

        protected virtual void OnDisable()
        {
            if (_binding == Binding.UNTIL_DISABLE)
            {
                ToggleRegistration(false);
                _cancellationTokenSource.Cancel();
            }
        }

        protected virtual void OnDestroy()
        {
            if (_binding == Binding.UNTIL_DESTROY)
            {
                ToggleRegistration(false);
                _cancellationTokenSource.Cancel();
            }
        }

        #endregion
    }
}
