using UnityEngine;
using UnityEngine.Events;

namespace PirateSoul.Components
{  
   public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private UnityEvent _action;
        [SerializeField] private UnityEvent _onComplete;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _action?.Invoke();
                _onComplete?.Invoke();

            }

        }

   }
}
