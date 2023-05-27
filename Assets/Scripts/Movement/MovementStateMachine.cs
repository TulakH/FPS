using System;
using System.Collections.Generic;
using System.Linq;
using FPS_Shooter.Assets.Scripts.Abstraction;
using UnityEngine;
using UnityEngine.Scripting;
using UnityGui;

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
        [SerializeField, RequireInterface(typeof(IState))]
        private UnityEngine.Object _defaultState;
        
        private Dictionary<MovementState, IState> _states;
        private CharacterMovement _physicalMovement;
        public IState CurrentState {get; private set;}
        

        private void Awake()
        {
            _states = GetComponents<IState>().ToDictionary(c => (MovementState)c.DefinitionState);
            CurrentState = _defaultState as IState;
        }

        
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