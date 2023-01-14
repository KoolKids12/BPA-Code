using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamanthus : MonoBehaviour
{
    
    [SerializeField] float health, maxhealth = 3f;
    
    [SerializeField]
    private GameObject FirePrefab;
    private GameObject OrcPrefab;

    [SerializeField]
    private float FireInterval = 10f;
   
    [SerializeField]
    private float OrcInterval = 35f;
   
    void Start()
    {
        StartCoroutine(spawnEnemy(FireInterval, FirePrefab));
        StartCoroutine(spawnEnemy(OrcInterval, OrcPrefab));
    }
     private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
         yield return new WaitForSeconds(interval);
         GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
          StartCoroutine(spawnEnemy(interval, enemy));
    }

        public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; // 3 -> 2 -> 1 -> dead
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
}
