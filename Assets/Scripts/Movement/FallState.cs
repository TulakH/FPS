using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPS_Shooter.Assets.Scripts.Abstraction;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    public class FallState : IState
    {
        public Enum DefinitionState => MovementState.Falling;

        public bool Enabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void OnStateEnter()
        {
            throw new NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new NotImplementedException();
        }

        public void OnStateUpdate()
        {
            throw new NotImplementedException();
        }
    }
}