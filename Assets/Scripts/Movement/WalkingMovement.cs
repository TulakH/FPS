using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPS_Shooter.Assets.Scripts.Control.Abstraction;
using FPS_Shooter.Assets.Scripts.Movement.Abstraction;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    public class WalkingMovement : MonoBehaviour, IMovementModifier
    {

        [SerializeField]
        private float _speed;

        private IMovementControls _movementControls;
        private CharacterMovement _characterMovement;

        public Vector3 Value {get; private set;}

        private Vector2 _walkedControl; 

        private void Start()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _movementControls = GetComponent<IMovementControls>();
            _movementControls.OnWalk += walkedControl;
        }

        private void walkedControl(InputAction.CallbackContext eventArg)
        {
            _walkedControl = eventArg.ReadValue<Vector2>();
        }

        private void calculateWalkingMovement()
        {
            Value = _characterMovement.Transform.right * _walkedControl.x + _characterMovement.Transform.forward * _walkedControl.y;
            Value *= _speed* Time.deltaTime;
            _walkedControl = Vector2.zero;
        }

        public void FixedUpdate()
        {
            calculateWalkingMovement();
        }

        public void OnDisable()
        {
            _characterMovement.RemoveMovementModifier(this);
        }

        public void OnEnable()
        {
            _characterMovement.AddMovementModifier(this);
        }
    }
}