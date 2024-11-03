using UnityEngine;
using UnityEngine.Events;

namespace PirateSoul.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private float _inputTimer;


        public void DestroyObject()
        {
             Destroy(_objectToDestroy, _inputTimer);
        }
        


    }
}
