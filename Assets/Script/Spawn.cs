using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemy;
    public Vector3 spawnValues;
    public float spawnwait;
    public int startwait;
    public float spawnLeastwait, spawnMostwait;
    public bool isstop;
    int randenemy;
    private float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnwait = Random.Range(spawnLeastwait, spawnMostwait);
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startwait);

        while(!isstop)
        {
            x = Random.Range(-spawnValues.x, spawnValues.x);
            y = spawnValues.y;
            z = Random.Range(-spawnValues.z, spawnValues.z);
            randenemy = Random.Range(0, 2);
            Vector3 spawnPosition = new Vector3 (x,y,z);

            Instantiate(enemy[randenemy], spawnPosition + transform.TransformPoint(0, 0, 0),gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnwait);
        }
    }
}
