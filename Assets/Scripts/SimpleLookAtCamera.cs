using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookAtCamera : MonoBehaviour
{

    public List<Transform> targets;
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 avg = Vector3.zero;
        int count = 0;

        foreach(Transform t in targets)
        {
            avg += t.position;
            count += 1;
        }

        avg.x = avg.x / count;
        avg.y = avg.y / count;
        avg.z = avg.z / count;

        transform.LookAt(avg);
    }
}
