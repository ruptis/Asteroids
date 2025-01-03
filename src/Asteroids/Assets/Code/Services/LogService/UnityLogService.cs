﻿using UnityEngine;

namespace Asteroids.Code.Services.LogService
{
    public sealed class UnityLogService : ILogService
    {
        public void Log(string message) => Debug.Log(message);

        public void LogWarning(string message) => Debug.LogWarning(message);

        public void LogError(string message) => Debug.LogError(message);
    }
}