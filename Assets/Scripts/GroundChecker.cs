using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private Transform _transform;

    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public bool CheckGrounded() => Physics.Raycast(_transform.position, Vector3.down);
}
