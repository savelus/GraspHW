using Components;
using Input;
using UnityEngine;

namespace Character {
    public class EntityMoveController {
        private readonly MoveComponent _moveComponent;
        private readonly IInputSystem _inputSystem;

        public EntityMoveController(MoveComponent moveComponent, IInputSystem inputSystem) {
            _moveComponent = moveComponent;
            _inputSystem = inputSystem;
            
            inputSystem.SubscribeOnHorizontalPositionChanged(ChangePosition);
        }

        private void ChangePosition(Vector2 distance) {
            _moveComponent.MoveByRigidbodyVelocity(distance);
        }
    }
}