/* Amal Presingu
 * 10/28/2021
 * Handling movement of asteroids and spawning them 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test {
    public class GameController : MonoBehaviour
    {
        public AsterController asterPrefab; //accessing AsterController class 
        public float spawnRate = 2f; //spawning rate
        public float spawnDistance = 7.5f;
        [Range(0.0f, 45.0f)]
        public float trajectoryVariance = 1.0f;
        public int spawnAmount = 1;


        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
        }

        public void Spawn()
        {
            for (int i = 0; i < this.spawnAmount; i++)
            {
                //float x = Random.Range(-6f, 6f); //randomized x position for each asteroid
                //float y = Random.Range(-6f, 6f);
                Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance; //spawning in circle outside of spawner
                Vector3 spawnPoint = this.transform.position + spawnDirection;
                spawnPoint += this.transform.position;

                float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward); //spatial rotation

                //asterPrefab.position = new Vector3(x, 6, 0);
                AsterController aster = Instantiate(this.asterPrefab, spawnPoint, rotation);

                aster.SetTrajectory(rotation * -spawnDirection);
            }
        }
    }
}

