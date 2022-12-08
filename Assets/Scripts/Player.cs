using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] private float _shrinkTime = 1.0f;
    [SerializeField] private float _speed = 1.0f;

    private void Start() {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            GameManager.PickUpKey(other.gameObject);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            if (GameManager.IsKeyCollected)
            {
                Debug.Log("You win!");
            }
        }
    }

    private void Update()
    {
        Move();
    }

#region Movement

    private void MoveUp()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }

    private void MoveDown()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void MoveLeft()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    private void MoveRight()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

#endregion


}
