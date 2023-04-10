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
        event Action<InputAction.CallbackContext> OnWalk;
        event Action<InputAction.CallbackContext> Jumped;
        event Action<InputAction.CallbackContext> OnMouseChanged;
    }
}