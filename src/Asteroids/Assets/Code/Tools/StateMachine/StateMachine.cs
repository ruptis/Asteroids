using System;
using Asteroids.Code.Services.LogService;
using Cysharp.Threading.Tasks;

namespace Asteroids.Code.Tools.StateMachine
{
    public abstract class StateMachine
    {
        private readonly ILogService _logService;
        private readonly StateFactory _stateFactory;

        protected StateMachine(StateFactory stateFactory, ILogService logService)
        {
            _stateFactory = stateFactory;
            _logService = logService;
        }

        protected IExitable CurrentState { get; private set; }

        public Type CurrentStateType => CurrentState?.GetType();

        public async UniTask Enter<TState>() where TState : class, IState
        {
            var state = await ChangeState<TState>();
            await state.Enter();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = await ChangeState<TState>();
            await state.Enter(payload);
        }

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitable
        {
            if (CurrentState != null) await CurrentState.Exit();
            
            _logService.Log($"Changing state from {CurrentStateType?.ToString() ?? "Start"} to {typeof(TState)}");
            var state = _stateFactory.GetState<TState>();
            CurrentState = state;

            return state;
        }
    }
}