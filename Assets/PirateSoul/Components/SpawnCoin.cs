using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PirateSoul.Components
{
    public class SpawnCoin : MonoBehaviour
    {
        public float spawnInterval = 2f;        // ���������� ������� ����� ��������
        public GameObject[] spawnPoints;        // ������ ����� ������
        public GameObject[] spawnObjects;       // ������ ��������, ������� ����� ����������
        private Dictionary<Vector2, bool> usedPositions = new Dictionary<Vector2, bool>();    // ������� �������, �� ������� ��� ���� �������

        void Start()
        {
            // ��������� ������� �������, ��������, ��� � ������ �� ���� �������� �������� ���
            foreach (GameObject spawnPoint in spawnPoints)
            {
                usedPositions.Add(spawnPoint.transform.position, false);
            }

            // �������� ����� SpawnObject ����� �������� ���������� ������� ������ ���
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
        }

        void SpawnObject()
        {
            // �������� ��������� ����� ������ �� ������� �����
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject spawnPoint = spawnPoints[spawnIndex];

            if (!usedPositions[spawnPoint.transform.position])
            {
                // �������� ��������� ������ ��� ������
                int objectIndex = Random.Range(0, spawnObjects.Length);
                GameObject objectToSpawn = spawnObjects[objectIndex];

                // ������� ������ �� ��������� �����
                Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);

                // �������� �������, ��� ��������������
                usedPositions[spawnPoint.transform.position] = true;
            }
        }

        public void FreePOsition(GameObject position)
        {
            usedPositions[position.transform.position] = false;
        }
    }
}
