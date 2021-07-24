using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] spawnPoints;
    public GameObject alien;
    public int maxAliensOnScreen;
    public int totalAliens;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int aliensPerSpawn;
    public float upgradeMaxTimeSpawn = 7.5f;
    private float actualUpgradeTime = 0;
    private int aliensOnScreen = 0;
    private float generatedSpawnTime = 0;
    private float currentSpawnTime = 0;
    public int currentLevel;
    private int nextLevel;
    public Text currentLevelText;
    public Animator stageAnimator;

    private void EndGame()
    {
        stageAnimator.SetTrigger("PlayerFinish");
    }

    public void AlienDestroyed()
    {
        aliensOnScreen -= 1;
        totalAliens -= 1;
        if (totalAliens == 0)
        {
            Invoke("EndGame", 2.0f);
        }
    }
    private void Update()
    {
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime > generatedSpawnTime)
        {
            currentSpawnTime = 0;
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            if (aliensPerSpawn > -1 && aliensOnScreen < totalAliens)
            {
                List<int> previousSpawnLocations = new List<int>();
                if (aliensPerSpawn > spawnPoints.Length)
                {
                    aliensPerSpawn = spawnPoints.Length - 1;
                }
                aliensPerSpawn = (aliensPerSpawn > totalAliens) ? aliensPerSpawn - totalAliens : aliensPerSpawn;
                for (int i = 0; i < aliensPerSpawn; i++)
                {
                    if (aliensOnScreen < maxAliensOnScreen)
                    {
                        aliensOnScreen += 1;
                        int spawnPoint = -1;
                        while (spawnPoint == -1)
                        {
                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                previousSpawnLocations.Add(randomNumber);
                                spawnPoint = randomNumber;
                            }
                        }
                        GameObject newAlien = Instantiate(alien);
                        newAlien.transform.position = spawnPoints[spawnPoint].transform.position;
                        newAlien.GetComponent<EnemyAttack>().Init(playerHealth);
                        newAlien.GetComponent<EnemyMovement>().Init(playerHealth);
                        EnemyHealth alienScript = newAlien.GetComponent<EnemyHealth>();
                        alienScript.buff = nextLevel;
                        alienScript.OnDestroy.AddListener(AlienDestroyed);
                    }
                }
            }
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            nextLevel = currentLevel;
            nextLevel++;
            PlayerPrefs.SetInt("CurrentLevel", nextLevel);
        }
        currentLevelText.text = currentLevel.ToString();
    }

    private void Start()
    {
        actualUpgradeTime = Random.Range(upgradeMaxTimeSpawn - 3.0f, upgradeMaxTimeSpawn);
        actualUpgradeTime = Mathf.Abs(actualUpgradeTime);
    }
}