using UnityEngine;
using UnityEngine.SceneManagement;

namespace PirateSoul.Components
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        public void Reload() // ������������ ����� �� �����������
        {
            var scene =  SceneManager.GetActiveScene(); // �������� �������� �����
            SceneManager.LoadScene(scene.name);

        }
    }
}
