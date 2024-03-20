using Bullets;
using Components;
using Input;
using UnityEngine;

namespace Character {
    public class EntityFireController {
        private readonly WeaponComponent _weapon;
        private readonly IInputSystem _inputSystem;
        private readonly BulletSystem _bulletSystem;
        private readonly BulletConfig _bulletConfig;

        public EntityFireController(WeaponComponent weapon, IInputSystem inputSystem, BulletSystem bulletSystem, BulletConfig bulletConfig) { //TODO придумать как по другому передавать буллет систем и конфиг
            _weapon = weapon;
            _inputSystem = inputSystem;
            _bulletSystem = bulletSystem;
            _bulletConfig = bulletConfig;

            _inputSystem.SubscribeOnFire(Fire);
        }

        private void Fire() {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args {
                isPlayer = true,
                physicsLayer = (int)_bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = _weapon.Position,
                velocity = _weapon.Rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}