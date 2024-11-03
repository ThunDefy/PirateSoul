using UnityEngine;

namespace PirateSoul.Components
{
    public class SwithComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;
        [SerializeField] private string _animatorKey;

        public void Switch()
        {
            _state = !_state;
            _animator.SetBool(_animatorKey, _state);
        }
    }
}
