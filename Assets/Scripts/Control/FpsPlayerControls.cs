using System;
using FPS_Shooter.Assets.Scripts.Control.Abstraction;
using UnityEngine;

namespace FPS_Shooter.Assets.Scripts.Control
{
    public class FpsPlayerControls : MonoBehaviour, IMovementControls
    {
        
        private FPSControls _fpsControls;
        public Vector2 Walk { get; private set; }
        public Vector2 Rotation { get; private set; }

        private void Awake()
        {
            _fpsControls = new FPSControls();
        }

        private void Update()
        {
            Walk = _fpsControls.Player.Move.ReadValue<Vector2>();
            Rotation = _fpsControls.Player.Look.ReadValue<Vector2>();
        }
        
        public event Action Jumped
        {
            add 
            {
                //_fpsControls.Player.Jump.performed += value;
            }
            remove
            {
                //_fpsControls.Player.Jump.performed -= value;
            }
        }


        private void OnEnable()
        {
            _fpsControls.Player.Enable();
        }

        private void OnDisable()
        {
            _fpsControls.Player.Disable();
        }
        
    }
}