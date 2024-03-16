using System;
using UnityEngine;

namespace Input {
    public sealed class InputArrowSystem : MonoBehaviour, IInputSystem {
        private Action<Vector2> _onHorizontalPositionChanged;
        private Action _onFire;
        public void SubscribeOnHorizontalPositionChanged(Action<Vector2> callback) {
            _onHorizontalPositionChanged += callback;
        }

        public void SubscribeOnFire(Action callback) {
            _onFire += callback;
        }

        private void FixedUpdate() {
            if (UnityEngine.Input.GetKey(KeyCode.Space)) {
                _onFire?.Invoke();
            }
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow)) {
                _onHorizontalPositionChanged?.Invoke(Vector2Int.left);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.RightArrow)) {
                _onHorizontalPositionChanged?.Invoke(Vector2Int.right);
            }
        }
    }
}