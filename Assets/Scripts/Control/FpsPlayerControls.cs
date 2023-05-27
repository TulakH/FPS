using System;
using FPS_Shooter.Assets.Scripts.Control.Abstraction;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Shooter.Assets.Scripts.Control
{
    public class FpsPlayerControls : MonoBehaviour, IMovementControls
    {
        private FPSControls _fpsControls;

        private void Awake()
        {
            _fpsControls = new FPSControls();
        }

        public event Action<InputAction.CallbackContext> OnWalk 
        {
            
            add 
            {
                _fpsControls.Player.Move.performed += value;
                
            }
            remove
            {
                _fpsControls.Player.Move.performed -= value;
            }
        }
        
        public event Action<InputAction.CallbackContext> Jumped
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
        
        public event Action<InputAction.CallbackContext> OnMouseChanged
        {
            add 
            {
                _fpsControls.Player.Look.performed += value;
            }
            remove
            {
                _fpsControls.Player.Look.performed -= value;
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