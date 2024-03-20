using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components {
    public sealed class HitPointsComponent : MonoBehaviour {
        private Action<GameObject> _onDeath;

        [SerializeField] private int _hitPoints;

        public bool IsHitPointsExists => _hitPoints > 0;

        public void TakeDamage(int damage) {
            _hitPoints = _hitPoints - damage > 0
                ? _hitPoints - damage
                : 0;

            if (_hitPoints <= 0) {
                _onDeath?.Invoke(gameObject);
            }
        }

        public void SubscribeOnDeath(Action<GameObject> callback) => _onDeath += callback;
        public void UnsubscribeOnDeath(Action<GameObject> callback) => _onDeath -= callback;
    }
}