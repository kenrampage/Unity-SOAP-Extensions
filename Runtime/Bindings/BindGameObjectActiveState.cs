using UnityEngine;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Bindings
{
    /// <summary>
    /// Binds a BoolVariable to a GameObject's active state.
    /// When the variable changes, the target GameObject is activated or deactivated accordingly.
    /// Supports an invert option to flip the relationship (false = active, true = inactive).
    /// If no target is assigned, falls back to this GameObject.
    /// </summary>
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Bindings/Bind GameObject Active State")]
    public class BindGameObjectActiveState : MonoBehaviour
    {
        #region Inspector

        [Tooltip("The BoolVariable that drives the active state of the target GameObject.")]
        [SerializeField] private BoolVariable _variable;

        [Tooltip("The GameObject to activate or deactivate. If unassigned, falls back to this GameObject.")]
        [SerializeField] private GameObject _targetObject;

        [Header("Settings")]

        [Tooltip("When enabled, the active state is inverted: false = active, true = inactive.")]
        [SerializeField] private bool _invert = false;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            ResolveTargetObject();

            if (_variable == null)
            {
                return;
            }

            Refresh(_variable.Value);
            _variable.OnValueChanged += Refresh;
        }

        private void OnDestroy()
        {
            if (_variable != null)
            {
                _variable.OnValueChanged -= Refresh;
            }
        }

        #endregion

        #region Registration

        private void ResolveTargetObject()
        {
            if (_targetObject == null)
            {
                _targetObject = gameObject;
            }
        }

        #endregion

        #region Invocation

        private void Refresh(bool value)
        {
            if (_targetObject == null)
            {
                return;
            }

            _targetObject.SetActive(_invert ? !value : value);
        }

        #endregion
    }
}
