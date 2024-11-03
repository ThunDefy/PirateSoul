using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PirateSoul.Components
{
    
    public class InteractableComponent : MonoBehaviour
    {
       // [SerializeField] private GameObject _activateButton;
        [SerializeField] private UnityEvent _action;
        //[SerializeField] private LayerMask _target;

        //private void Update()
        //{
        //    var size = Physics2D.OverlapCircleNonAlloc(transform.position, 0.5f,
        //        new Collider2D[1], _target);
        //    if (size > 0)
        //    {
        //        _activateButton.SetActive(true);
        //    }
        //    else
        //    {
        //        _activateButton.SetActive(false);
        //    }
        //}

        public void Interact()
        {
            _action?.Invoke();
        }
    }
}
