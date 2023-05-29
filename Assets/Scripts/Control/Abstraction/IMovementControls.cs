using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Shooter.Assets.Scripts.Control.Abstraction
{
    public interface IMovementControls
    {
        public Vector2 Walk { get; }
        public Vector2 Rotation { get; }
        event Action Jumped;
        
        //event Action<InputAction.CallbackContext> OnMouseChanged;
    }
}