using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Tools.StateMachine
{
    public interface IExitable
    {
        UniTask Exit();
    }
}