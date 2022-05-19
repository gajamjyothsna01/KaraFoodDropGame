using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningFruits : MonoBehaviour
{
    //public GameObject[] objects;
    float time = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        time = time + Time.deltaTime;
        Vector3 randomPoint = new Vector3(UnityEngine.Random.Range(-10f, 10f), 3f, 0f);
        if (time > 5f)
        {

            //int k = UnityEngine.Random.Range(0, objects.Length);
            // Instantiate(objects[k],randomPoint, Quaternion.identity);
            int k = PoolManager.instance.poolItems.Count;
            Debug.Log(k);
            int value = UnityEngine.Random.Range(0, PoolManager.instance.poolItems.Count);
            GameObject temp = PoolManager.instance.poolItems[value].prefab;

          // GameObject p1 = PoolManager.instance.GetObjectsFromPool("Food");
          //  GameObject temp2 = PoolManager.instance.GetObjectsFromPool("Obstacle");
            
            if(temp!= null)
            {
                temp.transform.position = randomPoint;
                temp.SetActive(true);
            }
            /*
            if (p1 != null)
            {
                p1.transform.position = randomPoint;
                p1.SetActive(true);
            }*/
            //  int k = UnityEngine.Random.Range(0, );
            StartCoroutine("DelaySpawning");
            time = 0f;
        }
       
      

    }
    IEnumerator DelaySpawning()
    {
        Debug.Log("Coroutine Function");
        yield return new WaitForSeconds(10);
    }
}
