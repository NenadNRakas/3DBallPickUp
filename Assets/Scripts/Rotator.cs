using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // No physics Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (21, 33, 42) * Time.deltaTime);
    }
}
