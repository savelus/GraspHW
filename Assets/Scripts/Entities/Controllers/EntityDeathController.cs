using Components;

namespace Character {
    public class EntityDeathController {
        private readonly HitPointsComponent _hitPointsComponent;
        private readonly GameManager.GameManager _gameManager;

        public EntityDeathController(HitPointsComponent hitPointsComponent, GameManager.GameManager gameManager) {
            _hitPointsComponent = hitPointsComponent;
            _gameManager = gameManager;

            _hitPointsComponent.SubscribeOnDeath(_ => Death());
        }

        private void Death() {
            _gameManager.FinishGame();
        }
    }
}