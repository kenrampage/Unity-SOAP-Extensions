using UnityEngine;
using Obvious.Soap;

namespace KenRampage.Addons.SOAP.Bindings
{
    /// <summary>
    /// Reads or writes transform position, rotation, or scale to/from a Vector3Variable.
    /// Supports world and local space, with optional per-axis constraints.
    /// If no target transform is assigned, falls back to this GameObject's transform.
    /// </summary>
    [AddComponentMenu("Ken Rampage/Addons/SOAP/Bindings/Bind Transform")]
    public class BindTransform : MonoBehaviour
    {
        #region Nested Types

        /// <summary>
        /// Defines whether to read from or write to the transform, and which property to operate on.
        /// </summary>
        public enum BindTransformOperation
        {
            ReadPosition,
            ReadRotation,
            ReadScale,
            WritePosition,
            WriteRotation,
            WriteScale
        }

        #endregion

        #region Inspector

        [Tooltip("The Vector3Variable to read from or write to.")]
        [SerializeField] private Vector3Variable _variable;

        [Tooltip("The transform to bind. If unassigned, falls back to this GameObject's transform.")]
        [SerializeField] private Transform _targetTransform;

        [Header("Settings")]

        [Tooltip("The operation to perform: read from the transform into the variable, or write the variable value to the transform.")]
        [SerializeField] private BindTransformOperation _operation = BindTransformOperation.WritePosition;

        [Tooltip("Use local space instead of world space. Applies to position and rotation only. Scale is always local.")]
        [SerializeField] private bool _useLocalSpace = false;

        [Header("Axis Constraints")]

        [Tooltip("Preserve the X axis of the current transform value instead of applying the variable's X.")]
        [SerializeField] private bool _ignoreX = false;

        [Tooltip("Preserve the Y axis of the current transform value instead of applying the variable's Y.")]
        [SerializeField] private bool _ignoreY = false;

        [Tooltip("Preserve the Z axis of the current transform value instead of applying the variable's Z.")]
        [SerializeField] private bool _ignoreZ = false;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            ResolveTargetTransform();

            if (_variable == null)
            {
                return;
            }

            if (IsReadOperation())
            {
                ReadIntoVariable();
            }
            else
            {
                WriteFromVariable(_variable.Value);
                _variable.OnValueChanged += WriteFromVariable;
            }
        }

        private void OnDestroy()
        {
            if (_variable != null)
            {
                _variable.OnValueChanged -= WriteFromVariable;
            }
        }

        #endregion

        #region Registration

        private void ResolveTargetTransform()
        {
            if (_targetTransform == null)
            {
                _targetTransform = transform;
            }
        }

        #endregion

        #region Read

        private void ReadIntoVariable()
        {
            if (_targetTransform == null)
            {
                return;
            }

            _variable.Value = GetTransformValue();
        }

        private Vector3 GetTransformValue()
        {
            Vector3 value;

            switch (_operation)
            {
                case BindTransformOperation.ReadPosition:
                    value = _useLocalSpace ? _targetTransform.localPosition : _targetTransform.position;
                    break;
                case BindTransformOperation.ReadRotation:
                    value = _useLocalSpace ? _targetTransform.localEulerAngles : _targetTransform.eulerAngles;
                    break;
                case BindTransformOperation.ReadScale:
                    value = _targetTransform.localScale;
                    break;
                default:
                    value = Vector3.zero;
                    break;
            }

            return ApplyReadConstraints(value);
        }

        #endregion

        #region Write

        private void WriteFromVariable(Vector3 newValue)
        {
            if (_targetTransform == null)
            {
                return;
            }

            newValue = ApplyWriteConstraints(newValue);

            switch (_operation)
            {
                case BindTransformOperation.WritePosition:
                    if (_useLocalSpace)
                        _targetTransform.localPosition = newValue;
                    else
                        _targetTransform.position = newValue;
                    break;
                case BindTransformOperation.WriteRotation:
                    if (_useLocalSpace)
                        _targetTransform.localEulerAngles = newValue;
                    else
                        _targetTransform.eulerAngles = newValue;
                    break;
                case BindTransformOperation.WriteScale:
                    _targetTransform.localScale = newValue;
                    break;
            }
        }

        #endregion

        #region Axis Constraints

        private Vector3 ApplyReadConstraints(Vector3 value)
        {
            Vector3 current = _variable != null ? _variable.Value : Vector3.zero;

            if (_ignoreX) value.x = current.x;
            if (_ignoreY) value.y = current.y;
            if (_ignoreZ) value.z = current.z;

            return value;
        }

        private Vector3 ApplyWriteConstraints(Vector3 newValue)
        {
            Vector3 current = GetCurrentTransformValue();

            if (_ignoreX) newValue.x = current.x;
            if (_ignoreY) newValue.y = current.y;
            if (_ignoreZ) newValue.z = current.z;

            return newValue;
        }

        private Vector3 GetCurrentTransformValue()
        {
            if (_targetTransform == null)
            {
                return Vector3.zero;
            }

            switch (_operation)
            {
                case BindTransformOperation.WritePosition:
                    return _useLocalSpace ? _targetTransform.localPosition : _targetTransform.position;
                case BindTransformOperation.WriteRotation:
                    return _useLocalSpace ? _targetTransform.localEulerAngles : _targetTransform.eulerAngles;
                case BindTransformOperation.WriteScale:
                    return _targetTransform.localScale;
                default:
                    return Vector3.zero;
            }
        }

        #endregion

        #region Helpers

        private bool IsReadOperation()
        {
            return _operation == BindTransformOperation.ReadPosition
                || _operation == BindTransformOperation.ReadRotation
                || _operation == BindTransformOperation.ReadScale;
        }

        #endregion
    }
}
