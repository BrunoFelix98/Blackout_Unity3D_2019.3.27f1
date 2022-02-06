using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible : MonoBehaviour
{
    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }
}
