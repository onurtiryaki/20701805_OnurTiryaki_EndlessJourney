using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CarController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Animator animator;
    [SerializeField] private float forwardSpeed;
    private float horizontal;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float horizontalLimit;
    private float newPositionX;


    private int score = 0;



    private void Update()
    {
        HandleDirectionInput();
    }


    private void FixedUpdate()
    {
        SetCarForwardMovement();
        SetCarHorizontalMovement();
    }



    private void HandleDirectionInput()
    {
        if(Input.GetMouseButton(0))
        {
            horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            horizontal = 0;
        }
        
    }


    private void SetCarForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.fixedDeltaTime);
    }


    private void SetCarHorizontalMovement()
    {
        newPositionX = transform.position.x + horizontal * horizontalSpeed * Time.fixedDeltaTime;
        ClampHorizontalValue();
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }



    private void ClampHorizontalValue()
    {
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimit, horizontalLimit);
    }
    private void IncreaseScoreValue()
    {
        score++;
        SetScoreTextValue();
        animator.SetTrigger("isScore");

        if (score%5==0)
        {
            forwardSpeed += 0.5f;
        }
    }


    private void SetScoreTextValue()
    {
        scoreText.text = score.ToString("00");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gold"))
        {
            IncreaseScoreValue();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Barrier"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
