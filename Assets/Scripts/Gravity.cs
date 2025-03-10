using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    private const float G = 0.006674f;
    public static List<Gravity> planetLists;

    private void FixedUpdate()
    {
        foreach (var planet in planetLists)
        {
            if (planet != this)
                Attract(planet);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetLists == null)
        {
            planetLists = new List<Gravity>();
        }
        planetLists.Add(this);
    }
    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;
        //get distance in meter
        float distance = direction.magnitude;

        //calculate Gravity force
        float forceManitude = G * (rb.mass * otherRb.mass)/Mathf.Pow(distance, 2);
        Vector3 finalForce = forceManitude * direction.normalized;

        otherRb.AddForce(finalForce);
    }
}
