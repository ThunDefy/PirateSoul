using UnityEngine;

namespace PirateSoul.Components
{
    public class TeleportComponent : MonoBehaviour
    {
        [SerializeField] private Transform _destTransform;

        public void Teleport(GameObject targer)
        {
            targer.transform.position = _destTransform.position;
        }
        
    }
}
