using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] private float _shrinkTime = 1.0f;
    [NonSerialized] private bool _canGoUp = true;
    [NonSerialized] private bool _canGoDown = true;
    [NonSerialized] private bool _canGoLeft = true;
    [NonSerialized] private bool _canGoRight = true;

    private void Start() {
        GameManager.OnDirectionPressed += Move;
        SwipeController.OnDirectionSwiped += Move;
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
        //on every frame, check if there is a wall on the corresponding side
        //if so, set the corresponding bool to false
        //if not, set the corresponding bool to true
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector3.down, 1.0f);

        // _canGoDown = !Physics2D.Raycast(transform.position, Vector3.down, 1f, LayerMask.GetMask("Wall"));
        Debug.Log(hit2D.transform.gameObject.tag);
    }

    // private IEnumerator ShrinkAnimate()
    // {
    //     Vector3 originalScale = transform.localScale;
    //     Vector3 destinationScale = (transform.localScale / 2f);

    //     float currentTime = 0f;

    //     while (currentTime <= _shrinkTime / 2)
    //     {
    //         currentTime += Time.deltaTime;
    //         transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime);
    //         yield return null;
    //     }
    //     while(currentTime <= _shrinkTime)
    //     {
    //         currentTime += Time.deltaTime;
    //         transform.localScale = Vector3.Lerp(destinationScale, originalScale, currentTime);
    //         yield return null;
    //     }
    // }

    // private IEnumerator MoveAnimate(Vector3 destination)
    // {
    //     Vector3 originalPosition = transform.position;
    //     Vector3 destinationPosition = destination;

    //     float currentTime = 0f;

    //     while (currentTime <= _shrinkTime)
    //     {
    //         currentTime += Time.deltaTime;
    //         transform.position = Vector3.Lerp(originalPosition, destinationPosition, currentTime);
    //         yield return null;
    //     }
    // }

#region Movement

    public void Move(int direction)
    {
        switch (direction)
        {
            case 0:
                MoveUp();
                break;
            case 1:
                MoveDown();
                break;
            case 2:
                MoveLeft();
                break;
            case 3:
                MoveRight();
                break;
        }
    }

    private void MoveUp()
    {
        if (_canGoUp)
            transform.position += Vector3.up;
    }

    private void MoveDown()
    {
        if (_canGoDown)
            transform.position += Vector3.down;
    }

    private void MoveLeft()
    {
        if (_canGoLeft)
            transform.position += Vector3.left;
    }

    private void MoveRight()
    {
        if (_canGoRight)
            transform.position += Vector3.right;
    }

#endregion


}
