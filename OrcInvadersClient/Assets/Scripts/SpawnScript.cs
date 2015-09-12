using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;


    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        var randomPos = new Vector3(transform.position.x + Random.Range(0f,4f), transform.position.y, transform.position.z);
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], randomPos, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));

    }
}
