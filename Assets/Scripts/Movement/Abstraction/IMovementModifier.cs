using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace FPS_Shooter.Assets.Scripts.Movement.Abstraction
{
    public interface IMovementModifier
    {
        void EnableModifier();
        void DisableModifier();
        Vector3 Value { get; }
    }
}