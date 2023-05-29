using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPS_Shooter.Assets.Scripts.Movement.Abstraction;
using UnityEngine;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    public class JumpMovement : MonoBehaviour, IMovementModifier
    {
        public Vector3 Value => throw new NotImplementedException();

        [SerializeField]
        private CharacterMovement _characterMovement;

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void DisableModifier()
        {
            throw new NotImplementedException();
        }

        public void EnableModifier()
        {
            throw new NotImplementedException();
        }
    }
}