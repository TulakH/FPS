using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPS_Shooter.Assets.Scripts.Abstraction;
using UnityEngine;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    public class GroundState : MonoBehaviour, IState
    {
        private IStateMachine _stateMachine;
        private CharacterMovement _physicalMovement;

        public Enum DefinitionState => MovementState.Ground;

        public void Awake()
        {
            _stateMachine = GetComponent<IStateMachine>();
            _physicalMovement = GetComponent<CharacterMovement>();
        }

        public void OnStateEnter()
        {
            //TODO ANIMATION
        }

        public void OnStateExit()
        {
            //TODO ANIMATION

        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set 
            {
                enabled = value;
            }
        }

        public void OnStateUpdate()
        {
            if (!_physicalMovement.IsGrounded)
            {
                _stateMachine.TransitionToState(MovementState.Falling);
            }
        }
    }
}