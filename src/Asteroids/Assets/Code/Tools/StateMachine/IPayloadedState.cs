using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Tools.StateMachine
{
    public interface IPayloadedState<in TPayload> : IExitable
    {
        UniTask Enter(TPayload payload);
    }
}