using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfContact : MonoBehaviour
{
    private void OntriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
