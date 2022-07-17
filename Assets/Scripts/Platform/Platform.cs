using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    public void Break()
    {
        PlatformSigment[] platformSigments = GetComponentsInChildren<PlatformSigment>();

        foreach (var sigment in platformSigments)
        {
            sigment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}
