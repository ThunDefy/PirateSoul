using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateSoul.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private ProgressBar _healthBar;

        public void UpdateHP(int newValue)
        {
            _healthBar.SetProgress(newValue);
        }
    }
}
