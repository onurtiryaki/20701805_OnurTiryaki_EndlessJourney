using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform carTransform;
    private Vector3 offset;
    private Vector3 newPos;

    [SerializeField] private float lerpValue;
    void Start()
    {
        // Kamera ile araba arasýndaki farký alýp offsete atadýk+
        offset = transform.position - carTransform.position;
    }


    // Kamera takip için daime lateupdate kullanýlmasý önerilir çünkü update metotlarýn hepsinden sonra çalýþýr
    void LateUpdate()
    {
        newPos = Vector3.Lerp(transform.position, carTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPos;
    }
}
