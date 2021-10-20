using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    // code from: https://stackoverflow.com/questions/51531677/unity-2d-trail-renderer-collision

    public TrailRenderer trail; //the trail
    //public GameObject TrailFollower;
    public GameObject ColliderPrefab;
    public float followDistance = 1f;

    public int poolSize = 5;
    GameObject[] pool;
    float trailRenderTime;
    GameObject player;

    void Start()
    {
        //trail = GetComponent<TrailRenderer>();
        trailRenderTime = trail.time;
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(ColliderPrefab);
        }
    }

    void Update()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (!trail.isVisible)
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i].gameObject.SetActive(false);

            }
        }
        else
        {
            TrailCollission();
        }

    }

    void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.forward * followDistance;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }

    void TrailCollission()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].gameObject.activeSelf == false)
            {
                pool[i].gameObject.SetActive(true);
                pool[i].gameObject.transform.position = transform.position;
                StartCoroutine(hide(trailRenderTime, pool[i].gameObject));
                return;
            }
        }
    }

    private IEnumerator hide(float waitTime, GameObject p)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            p.SetActive(false);

            yield break;
        }
        yield break;
    }
}
