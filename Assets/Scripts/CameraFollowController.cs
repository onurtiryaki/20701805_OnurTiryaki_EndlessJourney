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
        // Kamera ile araba aras�ndaki fark� al�p offsete atad�k+
        offset = transform.position - carTransform.position;
    }


    // Kamera takip i�in daime lateupdate kullan�lmas� �nerilir ��nk� update metotlar�n hepsinden sonra �al���r
    void LateUpdate()
    {
        newPos = Vector3.Lerp(transform.position, carTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPos;
    }
}
