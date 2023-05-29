using Cinemachine;
using UnityEngine;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    [RequireComponent(typeof(RotationMovement))]
    public class CameraControler : CinemachineExtension
    {
        [SerializeField] private float _clampAngle = 80f;
        
        private RotationMovement _rotationMovement;
        private Vector3 _startingRotation;

        protected override void Awake()
        {
            _rotationMovement = GetComponent<RotationMovement>();
            _startingRotation = transform.localRotation.eulerAngles;
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (vcam.Follow && stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = _rotationMovement.CameraRotation;
                _startingRotation.x += deltaInput.x 
                                       * _rotationMovement.SensitivityX 
                                       * _rotationMovement.Sensitivity 
                                       * deltaTime;
                _startingRotation.y += deltaInput.y 
                                       * _rotationMovement.SensitivityY 
                                       * _rotationMovement.Sensitivity
                                       * deltaTime;
                _startingRotation.y = Mathf.Clamp(_startingRotation.y, -_clampAngle, _clampAngle);
                state.RawOrientation = Quaternion.Euler(_startingRotation.y, _startingRotation.x, 0f);
            }
        }
    }
}