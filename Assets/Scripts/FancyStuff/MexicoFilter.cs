using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MexicoFilter : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Color colorLeft;
    [SerializeField] private Color colorRight;
    [SerializeField] private float leftMax;
    [SerializeField] private float rightMax;
    [SerializeField] private float lerp;
    
    void Update()
    {
        lerp = cameraTransform.position.x / rightMax - leftMax;
        Color dimColor = Color.Lerp(colorLeft, colorRight, lerp);
        
        volume.profile.TryGet (out ColorAdjustments colorAdjustments);

        colorAdjustments.colorFilter.value = dimColor;
    }
}
