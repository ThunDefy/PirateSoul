using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateSoul.UI.Hud
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private int _maxHP;
        [SerializeField] private Image _bar;

        private float newValue;

        public void SetProgress(int progress)
        {
            newValue = ((progress * 100f) / _maxHP) / 100f;
            _bar.fillAmount = newValue;
            Debug.Log(newValue);
        }
    }
}
