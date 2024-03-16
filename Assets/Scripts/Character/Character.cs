using Components;
using UnityEngine;

namespace Character {
    public class Character : MonoBehaviour {
        public HitPointsComponent HitPointsComponent;
        public WeaponComponent WeaponComponent;
        public TeamComponent TeamComponent;
        public MoveComponent MoveComponent;
    }
}