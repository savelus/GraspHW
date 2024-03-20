using Bullets;
using Input;
using UnityEngine;

namespace Character {
    public sealed class CharacterController : MonoBehaviour {
        [SerializeField] private GameManager.GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private Character _character;
        [SerializeField] private InputArrowSystem _inputSystem;


        private EntityMoveController _characterMoveController;
        private EntityFireController _characterFireController;
        private EntityDeathController _characterDeathController;

        private void Awake() {
            _characterMoveController = new EntityMoveController(_character.MoveComponent, _inputSystem);
            _characterFireController = new EntityFireController(_character.WeaponComponent, _inputSystem, _bulletSystem, _bulletConfig);
            _characterDeathController = new EntityDeathController(_character.HitPointsComponent, _gameManager);
        }
    }
}