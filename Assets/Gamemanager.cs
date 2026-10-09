using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
namespace Chapter.Singleton
{
    public class Gamemanager : Singleton<Gamemanager>
    {
        GameObject player;
        public GameObject goal;
        public EnemySpawner spawner;
        public bool isPaused = false;
        public float timer = 0f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            player = GameObject.Find("Player");
            spawner = FindAnyObjectByType<EnemySpawner>();
            goal = GameObject.Find("Goal");

            SpawnLoop();
            deathRestart();

            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                ResumeGame();
            }
        }

        public void deathRestart()
        {
            if (Input.GetKeyDown(KeyCode.R) && player.GetComponent<Movement>().isDead == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                player.GetComponent<Movement>().isDead = false;
            }
        }

        public void SpawnLoop()
        {
            timer += Time.deltaTime;
            if(timer >= 3)
            {
                Enemy enemy = spawner.SpawnEnemy();
                timer = 0;
            }
        }

        public void PauseGame()
        {
            isPaused = true;
            Time.timeScale = 0;
            Debug.Log("Game is Paused");
        }

        public void ResumeGame()
        {
            isPaused = false;
            Time.timeScale = 1;
            Debug.Log("Game is unpaused");
        }
    }
}