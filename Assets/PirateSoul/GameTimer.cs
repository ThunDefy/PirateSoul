using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PirateSoul.Components
{
    public class GameTimer : MonoBehaviour
    {

        [SerializeField] private float _timeStart = 60; 
        [SerializeField] private Text timerText;
        [SerializeField] private UnityEvent _timerEndAction;
        private bool stopTimer = false ;

        private void Start()
        {
            timerText.text = _timeStart.ToString();
        }

        private void Update()
        {
            if (_timeStart <= 0f && stopTimer == false )
            {
                _timerEndAction?.Invoke();
                stopTimer = true ;
            }
            else
            {
                _timeStart -= Time.deltaTime;
                timerText.text = Mathf.Round(_timeStart).ToString();
            }
           
            
        }

        public void AddTime(float seconds)
        {
            _timeStart += seconds;
        }
    }
}
