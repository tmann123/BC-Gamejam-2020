using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public float timer;

    private float elapsedTime;
    ObjectPooler objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (elapsedTime >= timer){
            objectPooler.SpawnFromPool("Boulder", transform.position, Quaternion.identity);
            elapsedTime = 0.0f;

        } else {
            elapsedTime += Time.deltaTime;
        }
    }
}
