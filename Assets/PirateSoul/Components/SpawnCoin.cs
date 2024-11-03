using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PirateSoul.Components
{
    public class SpawnCoin : MonoBehaviour
    {
        public float spawnInterval = 2f;        // промежуток времени между спавнами
        public GameObject[] spawnPoints;        // массив точек спавна
        public GameObject[] spawnObjects;       // массив объектов, которые будут спавниться
        private Dictionary<Vector2, bool> usedPositions = new Dictionary<Vector2, bool>();    // словарь позиций, на которых уже есть объекты

        void Start()
        {
            // заполняем словарь позиций, указывая, что в начале на этих позициях объектов нет
            foreach (GameObject spawnPoint in spawnPoints)
            {
                usedPositions.Add(spawnPoint.transform.position, false);
            }

            // вызываем метод SpawnObject через заданный промежуток времени каждый раз
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
        }

        void SpawnObject()
        {
            // выбираем случайную точку спавна из массива точек
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject spawnPoint = spawnPoints[spawnIndex];

            if (!usedPositions[spawnPoint.transform.position])
            {
                // выбираем случайный объект для спавна
                int objectIndex = Random.Range(0, spawnObjects.Length);
                GameObject objectToSpawn = spawnObjects[objectIndex];

                // спавним объект на выбранной точке
                Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);

                // помечаем позицию, как использованную
                usedPositions[spawnPoint.transform.position] = true;
            }
        }

        public void FreePOsition(GameObject position)
        {
            usedPositions[position.transform.position] = false;
        }
    }
}
