using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PirateSoul.UI.MainMenu
{
    public class MainMenuWindow : AnimatedWindow
    {
        
        public void OnShowLevels()
        {
            var window = Resources.Load<GameObject>("UI/SelectionWindow");
            var canvas = FindObjectOfType<Canvas>();
            Instantiate(window, canvas.transform);
        }
        public void OnStartGame()
        {
            Close();
        }

        public void OnExit()
        {
            Application.Quit();
        }

        public override void OnCloseAnimationCompete()
        {
            base.OnCloseAnimationCompete();
            SceneManager.LoadScene("Level1");
            
        }
    }
}
