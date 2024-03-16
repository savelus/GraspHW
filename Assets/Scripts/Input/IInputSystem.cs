using System;
using UnityEngine;

namespace Input {
    public interface IInputSystem {
        void SubscribeOnHorizontalPositionChanged(Action<Vector2> callback);

        void SubscribeOnFire(Action callback);
    }
}