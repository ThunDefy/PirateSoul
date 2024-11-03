using UnityEngine;
using UnityEngine.SceneManagement;

namespace PirateSoul.Components
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload() // Перезагрузим сцену на изначальную
        {
            var scene =  SceneManager.GetActiveScene(); // Получаем активную сцену
            SceneManager.LoadScene(scene.name);

        }
    }
}
