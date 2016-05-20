using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    public enum SwipeDirection
    {
        INVALID,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public static SwipeDirection CurrentDirection = SwipeDirection.INVALID;
    public float TouchDistance = 20.0f;

    public static InputManager instance;

    // Use this for initialization
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GetSwipeDirection();

        DebugKeys();
    }

    void DebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            CurrentDirection = SwipeDirection.UP;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentDirection = SwipeDirection.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CurrentDirection = SwipeDirection.DOWN;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentDirection = SwipeDirection.LEFT;
        }
    }

    public SwipeDirection GetSwipeDirection()
    {
        CurrentDirection = SwipeDirection.INVALID;

        if(Input.touchCount > 0)
        {
            Touch inputTouch = Input.GetTouch(0);

            switch(inputTouch.phase)
            {
                case TouchPhase.Began:
                    {
                        startPosition = inputTouch.position;
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        Vector2 endPosition = inputTouch.position;
                        Vector2 direction = endPosition - startPosition;
                        Vector2 swipeType = Vector2.zero;

                        if(Vector2.Distance(startPosition, endPosition) > TouchDistance)
                        {
                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            //Determines swipe direction
                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    CurrentDirection = SwipeDirection.RIGHT;
                                    Debug.Log("SwipedRight");
                                }
                                else
                                {
                                    CurrentDirection = SwipeDirection.LEFT;
                                    Debug.Log("SwipedLeft");
                                }
                            }
                            else if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    CurrentDirection = SwipeDirection.UP;
                                    Debug.Log("SwipedUp");
                                }
                                else
                                {
                                    CurrentDirection = SwipeDirection.DOWN;
                                    Debug.Log("SwipedDown");
                                }
                            }
                        }
                        break;
                    }
            }
        }
        return CurrentDirection;
    }

    Vector2 startPosition;
}
