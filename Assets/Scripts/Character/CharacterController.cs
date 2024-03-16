using System;
using Bullets;
using Components;
using Input;
using UnityEngine;

namespace Character {
    public sealed class CharacterController : MonoBehaviour {
        [SerializeField] private GameObject _characterGO;
        [SerializeField] private GameManager.GameManager gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        [SerializeField] private Character _character;
        [SerializeReference] private InputArrowSystem _inputManager;
        
        public bool _fireRequired;

        private EntityMoveController _entityMoveController;
        
        private void Awake() {
            _entityMoveController = new EntityMoveController(_character.MoveComponent, _inputManager);
        }

        private void OnEnable() {
            this._characterGO.GetComponent<HitPointsComponent>().hpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable() {
            this._characterGO.GetComponent<HitPointsComponent>().hpEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();

        private void FixedUpdate() {
            if (_fireRequired) {
                OnFlyBullet();
                _fireRequired = false;
            }
        }

        private void OnFlyBullet() {
            var weapon = this._characterGO.GetComponent<WeaponComponent>();
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args {
                isPlayer = true,
                physicsLayer = (int)this._bulletConfig.physicsLayer,
                color = this._bulletConfig.color,
                damage = this._bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * this._bulletConfig.speed
            });
        }
    }
}