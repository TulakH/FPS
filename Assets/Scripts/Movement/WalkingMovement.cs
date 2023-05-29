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
        private float _speed = 5;
        [SerializeField]
        private CharacterMovement _characterMovement;

        private IMovementControls _movementControls;
        
        
        public Vector3 Value {get; private set;}

        private Vector2 _walkedControl;

        private void Start()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _movementControls = GetComponent<IMovementControls>();
        }
        
        public void FixedUpdate()
        {
            calculateWalkingMovement();
        }

        public void DisableModifier()
        {
            _characterMovement.RemoveMovementModifier(this);
        }

        public void EnableModifier()
        {
            _characterMovement.AddMovementModifier(this);
        }
        
        private void walkedControl(Vector2 wasd)
        {
            _walkedControl = wasd;
            Debug.Log(_walkedControl);
        }

        private void calculateWalkingMovement()
        {
            Value = _characterMovement.Transform.right * _movementControls.Walk.x +
                    _characterMovement.Transform.forward * _movementControls.Walk.y;
            Value *= _speed * 50;
            Debug.Log(Value);
        }

        
    }
}