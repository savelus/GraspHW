using Components;
using Input;
using UnityEngine;

namespace Character {
    public class EntityMoveController {
        private readonly MoveComponent moveComponent;
        private readonly IInputSystem _inputSystem;

        public EntityMoveController(MoveComponent moveComponent, IInputSystem inputSystem) {
            this.moveComponent = moveComponent;
            this._inputSystem = inputSystem;
            
            inputSystem.SubscribeOnHorizontalPositionChanged(ChangePosition);
        }

        private void ChangePosition(Vector2 distance) {
            moveComponent.MoveByRigidbodyVelocity(distance);
        }
    }
}