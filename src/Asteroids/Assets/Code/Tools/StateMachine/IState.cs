using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Tools.StateMachine
{
    public interface IState : IExitable
    { 
        UniTask Enter();
    }
}