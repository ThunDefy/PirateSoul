using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PirateSoul
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        private void Awake()
        {
            //_hero = GetComponent<Hero>(); // т.к. сериалайз переменная, отношение можно присваивать в юнити
        }
        //private void Update()
        //{
        //    var horizontal = Input.GetAxis("Horizontal");
        //    _hero?.SetDirection(horizontal);

        //    if (Input.GetButtonUp("Fire1"))
        //    {
        //        _hero.SaySomething();
        //    }


        //    //if (Input.GetKey(KeyCode.A))
        //    //{
        //    //    _hero?.SetDirection(-1);

        //    //}
        //    //else if (Input.GetKey(KeyCode.D))
        //    //{
        //    //    _hero?.SetDirection(1);
        //    //}
        //    //else
        //    //{
        //    //    _hero?.SetDirection(0);
        //    //}

        //}

        public void Movement(InputAction.CallbackContext context)
        {
            Vector2 dir = context.ReadValue<Vector2>(); // Срабатывает по событию нажатия именно когда нажали на кнопку
            _hero?.SetDirection(dir);
        }

        //public void MovementOnButtons(float x)
        //{
        //    Vector2 dir = new Vector2(x, _hero.transform.position.y); 
        //    _hero?.SetDirection(dir);
        //}
        //public void JumpOnButtons(float y)
        //{
        //    Vector2 dir = new Vector2(0, y );
        //    _hero?.SetDirection(dir);
        //}


        public void OnSaySomthing(InputAction.CallbackContext context)
        {
            if (context.canceled)// Флаг фазы, сейчас окончание
            {
                _hero?.SaySomething();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero?.Interact();
            }
        }

    }
}
