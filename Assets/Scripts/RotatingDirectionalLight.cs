using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDirectionalLight : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private Transform lightTransform;

    private void Start()
    {
        lightTransform = transform;
    }

    private void Update()
    {
        var eulerAngles = lightTransform.eulerAngles;
        var newYRotation = (eulerAngles.y + rotationSpeed * Time.deltaTime) % 360f;
        eulerAngles = new Vector3(eulerAngles.x, newYRotation, eulerAngles.z);
        lightTransform.eulerAngles = eulerAngles;
    }
}
