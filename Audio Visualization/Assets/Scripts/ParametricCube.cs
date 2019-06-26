using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametricCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;

    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.frequencyBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
