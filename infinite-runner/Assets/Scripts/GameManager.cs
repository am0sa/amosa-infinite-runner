using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameObject menuOverlay;
    public GameObject userInterface;
    public Text highestScore;
    public Text currentScore;
    public Text longestLife;
    public Text currentLife;


    public GameObject bulletPrefab;  //delete from here-----
    public GameObject coinPrefab;
    public GameObject rareCoinPrefab;
    public GameObject blockPrefab;
    public GameObject smallPointsPrefab;
    public GameObject largePointsPrefab;
    public GameObject debrisPrebab;  //to here--------------
    public GameObject floorContainer;
    public GameObject player;
    private Transform FLOOR_DEFAULT;
    public Transform[] floorType;
    public GameObject[] ImageLoop;
    public GameObject[] prefabList;

    public float WORLD_LEFT_SPEED;

    public enum SpawnPos {fromAbove = 0, fromAhead = 1}
    public bool isPaused = false;

    void Awake()
    {
        SetInstance();
        isPaused = true;
        WORLD_LEFT_SPEED = 3f;
        FLOOR_DEFAULT = floorContainer.transform;
    }

    void Start()
    {
        InvokeRepeating("RandomSpawn", 6.9f, 1f);
        InvokeRepeating("RandomSpawn2", Random.Range(3, 7), 1f);
    }


    public void Update() 
    {
<<<<<<< HEAD
        var randomTempTime = Random.Range(0f, 20f);
        var playerTime = player.GetComponent<MarioController>().currentLife;
        if (playerTime >= 15 + randomTempTime)
=======
        if (player.GetComponent<MarioController>().currentLife >= 15)
>>>>>>> parent of 7f7de6b... Post Test
        {
            if (playerTime >= 30)
            {
                FloorChange(1);
            }
            else
            {
                FloorChange(0);
            }
        }
<<<<<<< HEAD
        else if (playerTime >= 2.5 + randomTempTime)
=======
        else if (player.GetComponent<MarioController>().currentLife >= 2.5)
>>>>>>> parent of 7f7de6b... Post Test
        {
            FloorChange(1);
        }
    }

    public void FloorChange(int typeNumber)
    {
        if(floorContainer.transform != floorType[typeNumber])
        {
            Vector3 scaleChange = Vector3.MoveTowards(floorContainer.transform.localScale, floorType[typeNumber].transform.localScale, Time.deltaTime);
            Vector3 positionChange = Vector3.MoveTowards(floorContainer.transform.position, floorType[typeNumber].transform.position, 2.5f * Time.deltaTime);
            floorContainer.transform.position = positionChange;
            floorContainer.transform.localScale = scaleChange;
        }
    }

    void SetInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            menuOverlay.SetActive(true);
        }
    }

    public void UnpauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            menuOverlay.SetActive(false);
        }
    }

    public void RandomSpawn()  //y < 12, x > 20
    {
        GameObject prefab = prefabList[(int)(Random.Range(2, 7))];
        SpawnPos spawn = SpawnPos.fromAbove;

        float tempY = 0;
        float tempX = 0;

        if (spawn == SpawnPos.fromAbove)
        {
            tempY = 13f;
            tempX = Random.Range(-15f, 15f);
        }
        
        if(spawn == SpawnPos.fromAhead)
        {
            tempY = Random.Range(0, 12f);
            tempX = 20f;
        }

        GameObject temp = Instantiate(prefab, new Vector3(tempX, tempY, 0f), prefab.transform.rotation);
    }

    public void RandomSpawn2()  //y < 12, x > 20
    {
        GameObject prefab = prefabList[(int)(Random.Range(0, 3))];
        SpawnPos spawn = SpawnPos.fromAhead;

        float tempY = 0;
        float tempX = 0;

        if (spawn == SpawnPos.fromAbove)
        {
            tempY = 13f;
            tempX = Random.Range(-15f, 15f);
        }
        
        if(spawn == SpawnPos.fromAhead)
        {
            tempY = Random.Range(0, 6f);
            tempX = 20f;
        }

        GameObject temp = Instantiate(prefab, new Vector3(tempX, tempY, 0f), prefab.transform.rotation);
    }
}
