using System;
using System.Collections.Generic;
using System.Linq;
using FPS_Shooter.Assets.Scripts.Abstraction;
using UnityEngine;

namespace FPS_Shooter.Assets.Scripts.Movement
{
    public enum MovementState
    {
        Ground,
        Jumping,
        Falling
    }

    public class MovementStateMachine : MonoBehaviour, IStateMachine
    {
        private Dictionary<MovementState, IState> _states;
        private CharacterMovement _physicalMovement;


        private void Awake()
        {
            _states = GetComponents<IState>().ToDictionary(c => (MovementState)c.DefinitionState);
        }

        public IState CurrentState {get; private set;}
        
        public void TransitionToState(Enum toState)
        {
            CurrentState.OnStateExit();
            CurrentState.Enabled = false;
            CurrentState = _states[(MovementState)toState];
            CurrentState.Enabled = true;
            CurrentState.OnStateEnter();
        }
    }
}