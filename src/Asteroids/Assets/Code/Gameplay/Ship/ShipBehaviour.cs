﻿using System;
using Asteroids.Code.Configs;
using Asteroids.Code.Gameplay.Movement;
using Asteroids.Code.Services.ConfigService;
using UnityEngine;
using VContainer;

namespace Asteroids.Code.Gameplay.Ship
{
    public sealed class ShipBehaviour : MonoBehaviour
    {
        [SerializeField] private AcceleratedMovement _movement;
        [SerializeField] private Gun _gun;

        private ShipHealth _health;

        public IHealth Health => _health;
        
        public event Action Destroyed;

        [Inject]
        public void Construct(IConfigs configs)
        {
            PlayerConfig config = configs.GetPlayerConfig();

            _health = new ShipHealth(config.MaxHealth);
            _movement.Configure(config.MovementSpeed, config.RotationSpeed, config.AccelerationTime,
                config.DecelerationTime);
            _gun.Configure(config.GunConfig.FireRate, config.GunConfig.BulletSpeed);
        }
        
        public void DecreaseHealth(int amount)
        {
            _health.DecreaseHealth(amount);
            
            if (_health.CurrentHealth <= 0)
            {
                Destroy(gameObject);
                Destroyed?.Invoke();
            }
        }
    }
}