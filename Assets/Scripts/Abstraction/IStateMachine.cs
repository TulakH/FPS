using System;
namespace FPS_Shooter.Assets.Scripts.Abstraction
{
    public interface IStateMachine
    {
        //Enum CurrentState { get; }
        IState CurrentState { get; }


        void TransitionToState(Enum toState);
    }
}