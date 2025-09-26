using System.Collections;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]                             //Making the class serializable to view in the inspector
    public class Wave
    {
        public Enemy[] enemies;                //Using the array to store the enemies that need to be spawned
        public float timeBetweenSpawns = 3f;      //Time interval between spawning the enemies
        public float timeBetweenWaves = 10f;      //Time interval between spawning the waves
        public int enemiesCount;                    //Number of enemies in the wave
    }

    [SerializeField] private float countDown;            //Time interval for spawning the waves 
    public Wave[] waves;                 //Array to store the waves that can be spawned 
    public Transform[] spawnPoint;          //Spawn point for the enemies
    public int currentWave = 0;                        //current wave that is being spawning from the array 
    private bool countDownBegin;                       //Bool to check if the countdown has begun or not
    [SerializeField] private TextMeshProUGUI waveCountDownText; //Text to display the countdown timer


    private void Start()
    {
        countDownBegin = true;                        //Starting the countdown when the game starts
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesCount = waves[i].enemies.Length;      //Setting the enemy count for each wave based on the no.of enemies in the array 
        }
        waveCountDownText.text = "wave: " + currentWave.ToString();       //instailizing the wave count text
    }


    private void Update()
    {
        waveCountDownText.text = "wave: " + currentWave.ToString();
        if (currentWave >= waves.Length)
        {
            Debug.Log("All Waves Completed!");          //Debugging when all the waves are completed
            return;
        }
        if (countDownBegin == true)
        {
            countDown -= Time.deltaTime;                  //Decreasing the countdown time when the game start running
        }


        if (countDown <= 0f)
        {
            countDownBegin = false;                      //Stopping the countdown when the wave is spawned
            countDown = waves[currentWave].timeBetweenWaves;   // Resetting the countdown timer for the waves to spawn
            //Spawn the Wave 
            StartCoroutine(SpawnWave());
        }

        if (waves[currentWave].enemiesCount == 0)
        {
            countDownBegin = true;                       //Starting the countdown when the wave is cleared
            currentWave++;                              //Increasing the wave index to spawn the next wave
        }
    }

    IEnumerator SpawnWave()
    {
        if (currentWave < waves.Length)
        {
            for (int i = 0; i < waves[currentWave].enemies.Length; i++)
            {
                Transform spawnPoints = spawnPoint[Random.Range(0, spawnPoint.Length)]; //Choosing a random spawn point from the array
                Enemy enemy = Instantiate(waves[currentWave].enemies[i], spawnPoints.position, Quaternion.identity);    //spawning the enemies at the spawn position
                enemy.transform.SetParent(spawnPoints);                                                     // Using it to store spawned enemies in the hierarchy under the spawn point for optimazation
                yield return new WaitForSeconds(waves[currentWave].timeBetweenSpawns);                   //waiting for time between spawning the enemies 
            }
            Debug.Log("Wave Spawned");                    //Debugging the wave spawning 
        }
    }
}
