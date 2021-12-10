using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUN : MonoBehaviour
{
    public float rotSpeed;

    public void Update()
    {
        transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
    }
}
