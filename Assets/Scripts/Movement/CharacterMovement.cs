using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPS_Shooter.Assets.Scripts.Movement.Abstraction;
using UnityEngine;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private GroundChecker _groundChecker;
        public bool IsGrounded => _groundChecker.CheckGrounded();

        private readonly List<IMovementModifier> _movementModifiers = new List<IMovementModifier>();
        public Transform Transform { get; private set; }

        public void AddMovementModifier(IMovementModifier movementModifier) => _movementModifiers.Add(movementModifier);
        public void RemoveMovementModifier(IMovementModifier movementModifier) => _movementModifiers.Remove(movementModifier);

        private void Awake()
        {
            _rigidbody = GetComponentInChildren<Rigidbody>();
            _groundChecker = GetComponentInChildren<GroundChecker>();
            
            Transform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            move();
        }

        private void move()
        {
            foreach (var modifier in _movementModifiers)
            {
                Debug.Log($"{modifier.GetType().FullName} force : {modifier.Value}");
                _rigidbody.AddForce(modifier.Value);
            }
        }
    }
}