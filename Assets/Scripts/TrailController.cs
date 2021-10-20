using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    // code from: https://stackoverflow.com/questions/51531677/unity-2d-trail-renderer-collision

    public static TrailController Instance;

    public TrailRenderer trail; //the trail
    //public GameObject TrailFollower;
    public GameObject ColliderPrefab;
    

    public int poolSize = 1;
    GameObject[] pool;
    float trailRenderTime;

    public EncircledArea encircledArea;

    public float diameter;
    public Vector3 center;

    private void Awake() {
        Instance = this;
    }

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

        Vector3[] points = new Vector3[poolSize];
        trail.GetPositions(points);
        for (int i = 0; i < poolSize; i++) {
            pool[i].SetActive(false);
        }

        float minDistanceToPlayer = 0.5f;
        bool tooClose = true;

        Vector3 firstPoint = Vector3.zero;
        float newDiameter = 0;
        Vector3 newCenter = Vector3.zero;
        for (int i = points.Length - 1; i > 0; i--) {
            if (points[i].x == 0 && points[i].y == 0) continue;

            if (tooClose) {
                float distanceToPlayer = Vector3.Distance(points[i], PlayerMovement.Instance.transform.position);
                if (distanceToPlayer > minDistanceToPlayer) tooClose = false;
                else continue;
            }

            if (firstPoint == Vector3.zero) firstPoint = points[i];

            Vector3 toFirstPoint = firstPoint - points[i];
            if (toFirstPoint.magnitude > newDiameter) {
                newDiameter = toFirstPoint.magnitude;
                Vector3 toCenter = toFirstPoint / 2;
                newCenter = points[i] + toCenter;
            }
            
            pool[i].SetActive(true);
            pool[i].transform.position = points[i];
        }

        diameter = newDiameter;
        center = newCenter;
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
