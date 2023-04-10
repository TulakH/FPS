using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPS_Shooter.Assets.Scripts.Abstraction
{
    public interface IState
    {
        bool Enabled {get; set;}
        Enum DefinitionState {get;}
        void OnStateEnter();
        void OnStateExit();
        void OnStateUpdate();
    }
}