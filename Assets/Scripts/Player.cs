using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawPlayerInput;
    Vector2 minimumBoundry;
    Vector2 maximumBoundry;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingTop;

    void Start()
    {
        InitBoundries();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector2 delta = rawPlayerInput * moveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minimumBoundry.x + paddingLeft, maximumBoundry.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minimumBoundry.y + paddingBottom, maximumBoundry.y - paddingTop);
        transform.position = newPosition;
    }

    void InitBoundries()
    {
        Camera mainCamera = Camera.main;
        minimumBoundry = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maximumBoundry = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value)
    {
        rawPlayerInput = value.Get<Vector2>();
        Debug.Log(rawPlayerInput);
    }
}