using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    // code from: https://stackoverflow.com/questions/51531677/unity-2d-trail-renderer-collision

    public TrailRenderer trail; //the trail
    //public GameObject TrailFollower;
    public GameObject ColliderPrefab;
    

    public int poolSize = 5;
    GameObject[] pool;
    float trailRenderTime;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trailRenderTime = trail.time;
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(ColliderPrefab);
        }
    }

    void Update()
    {
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
