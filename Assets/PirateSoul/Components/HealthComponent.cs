using PirateSoul.UI.Hud;
using UnityEngine;
using UnityEngine.Events;

namespace PirateSoul.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health = 5;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HudController _hud;

        public void ApplyDamage(int damageValue)
        {
            _health -= damageValue;
            if(damageValue>0) _onDamage?.Invoke(); // вызываем эвент
            _hud.UpdateHP(_health);

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
    }

   
}
