using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCntrl : MonoBehaviour
{
    public GameObject Character;
    private Vector3 OffSet;
    // Start is called before the first frame update
    void Start()
    {
        OffSet = transform.position - Character.transform.position;
    }

    // Garanteed to run after Update is called once per frame
    void LateUpdate()
    {
        transform.position = Character.transform.position + OffSet;
    }
}
