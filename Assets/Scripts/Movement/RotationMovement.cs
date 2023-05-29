using FPS_Shooter.Assets.Scripts.Control.Abstraction;
using FPS_Shooter.Assets.Scripts.Movement.Abstraction;
using UnityEngine;
using UnityEngine.Serialization;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    public class RotationMovement: MonoBehaviour, IMovementModifier
    {
        [SerializeField]
        private CharacterMovement _characterMovement;

        [SerializeField] public float Sensitivity = 10;
        [SerializeField] public float SensitivityY = 1;
        [SerializeField] public float SensitivityX = 1;
        
        private IMovementControls _movementControls;
        
        public Vector2 CameraRotation { get; private set; }
        
        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _movementControls = GetComponent<IMovementControls>();
        }

        public void DisableModifier()
        {
            _characterMovement.RemoveMovementModifier(this);
        }

        public void EnableModifier()
        {
            _characterMovement.AddMovementModifier(this);
        }

        public Vector3 Value { get; private set; }

        private void Update()
        {
            Value = _characterMovement.Transform.eulerAngles +
                    new Vector3(0, _movementControls.Rotation.x * SensitivityX * Sensitivity, 0);
            Debug.Log($"Rotation : {Value}");

        }
    }
}