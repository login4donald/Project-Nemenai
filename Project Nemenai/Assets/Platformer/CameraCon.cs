using UnityEngine;
using System.Collections;

public class CameraCon : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothValue = 0.15f;
    public bool lockY;

    void Update()
    {
        Vector3 V = target.position;
        V.x += offset.x;
        if (!lockY) V.y += offset.y; else V.y = offset.y;
        V.z += offset.z;
        transform.position = Vector3.Lerp(transform.position, V, smoothValue);
    }

    [ContextMenu("Default Offset")]
    public void DefaultOffset()
    {
        offset.x = +00;
        offset.y = +04;
        offset.z = -10;
    }
}
