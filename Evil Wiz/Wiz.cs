using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiz : MonoBehaviour
{
    [SerializeField]
    private GameObject FirePrefab;

    [SerializeField]
    private float FireInterval = 10f;
   
    void Start()
    {
        StartCoroutine(spawnEnemy(FireInterval, FirePrefab));
    }
     private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
         yield return new WaitForSeconds(interval);
         GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
          StartCoroutine(spawnEnemy(interval, enemy));
    }
}
