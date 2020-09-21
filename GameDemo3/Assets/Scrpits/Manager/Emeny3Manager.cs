using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeny3Manager : MonoBehaviour
{
    public static Emeny3Manager Instance = null;
    public GameObject[] Enemy3L;
    public GameObject[] Enemy3R;
    int numberOfEnemy3Ls;
    int numberOfEnemy3Rs;

    int toggleTime;
    [SerializeField]
    GameObject Enemy3LPrefab;
    [SerializeField]
    GameObject Enemy3RPrefab;
    void Awake()
    {
        numberOfEnemy3Ls = Enemy3L.Length;

        if (numberOfEnemy3Ls - 1 == 0) { toggleTime = 1; } else { toggleTime = numberOfEnemy3Ls - 1; }

        numberOfEnemy3Rs = Enemy3R.Length;

        if (numberOfEnemy3Rs - 1 == 0) { toggleTime = 1; } else { toggleTime = numberOfEnemy3Rs - 1; }

        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(gameObject); }


    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfEnemy3Ls; i++)
        {
            Instantiate(Enemy3LPrefab, Enemy3L[i].transform.position, Enemy3LPrefab.transform.rotation);
            Enemy3L[i].SetActive(false);
        }
        for (int i = 0; i < numberOfEnemy3Rs; i++)
        {
            Instantiate(Enemy3RPrefab, Enemy3R[i].transform.position, Enemy3RPrefab.transform.rotation);
            Enemy3R[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy3L(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(8f);
        Instantiate(Enemy3LPrefab, spawnPosition, Enemy3LPrefab.transform.rotation);
    }
    IEnumerator SpawnEnemy3R(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(8f);
        Instantiate(Enemy3RPrefab, spawnPosition, Enemy3RPrefab.transform.rotation);
    }
}
