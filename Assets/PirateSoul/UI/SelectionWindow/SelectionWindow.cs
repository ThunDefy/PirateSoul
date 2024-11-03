using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

namespace PirateSoul.UI.SelectionWindow
{
    public class SelectionWindow : AnimatedWindow
    {
        private string _level;
        public void OnStartLevel1()
        {
            _level = "Level1";
            Close();
        }
        public void OnStartLevel2()
        {
            _level = "Level2";
            Close();
        }

        public override void OnCloseAnimationCompete()
        {
            base.OnCloseAnimationCompete();
            if(_level!=null) SceneManager.LoadScene(_level);

        }
    }
}
