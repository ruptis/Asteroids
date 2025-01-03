﻿using VContainer;

namespace Asteroids.Code.Tools.StateMachine
{
    public sealed class StateFactory
    {
        private readonly IObjectResolver _resolver;

        public StateFactory(IObjectResolver resolver) =>
            _resolver = resolver;

        public TState GetState<TState>() where TState : class, IExitable =>
            _resolver.Resolve<TState>();
    }
}