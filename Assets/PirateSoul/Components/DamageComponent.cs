using UnityEngine;

namespace PirateSoul.Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private bool _itsHeal;

        public void ApplyDamage(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (_itsHeal) _damage *= -1;
            if (healthComponent != null)
            {
                healthComponent.ApplyDamage(_damage);
            }
        }

        
    }
}
