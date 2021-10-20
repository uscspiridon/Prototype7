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

        Vector3[] points = new Vector3[100];
        trail.GetPositions(points);
        Vector3 testPoint = points[points.Length - 1];
        int startIndex = 0;
        for (int i = 0; i < points.Length; i++) {
            Debug.Log("i " + i + " , x = " + points[i].x + " y = " + points[i].y);
            float distance = Vector3.Distance(testPoint, points[i]);
            // closed loop detected
            if (distance < trail.minVertexDistance) {
                startIndex = i;
                break;
            }
        }
        // for (int i = startIndex; true; i++) {
        //     
        // }

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
