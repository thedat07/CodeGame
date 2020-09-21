using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;
    public GameObject[] Platform;
    int numberOfPlatforms;

    int toggleTime;
    [SerializeField]
    GameObject platformPrefab;

    void Awake()
    {
        numberOfPlatforms = Platform.Length;

        if (numberOfPlatforms - 1 == 0) { toggleTime = 1; } else { toggleTime = numberOfPlatforms - 1; }


        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }
            

    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Instantiate(platformPrefab, Platform[i].transform.position, platformPrefab.transform.rotation);
            Platform[i].SetActive(false);
        }
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(8f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
