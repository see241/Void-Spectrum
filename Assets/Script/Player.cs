﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private delegate void del();

    private del Move;

    private Vector2 beginPos;
    private Vector2 lastPos;

    // Use this for initialization
    private void Start()
    {
        Move = MoveToTouch;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void MoveToKeyboard()
    {
        float vX = 0, vY = 0;
        if (Input.GetKey(KeyCode.W))
        {
            vY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vY = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vX = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vX = 1;
        }

        transform.Translate(new Vector2(vX, vY).normalized * Time.deltaTime * speed);
    }

    private void MoveToTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                beginPos = Camera.main.ScreenToWorldPoint(touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = lastPos + (Vector2)Camera.main.ScreenToWorldPoint(touch.position) - beginPos;
                if (Vector2.Distance(transform.position, Vector2.zero) > 4.25f)
                {
                    transform.position = transform.position.normalized * 4.24f;
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                lastPos = transform.position;
            }
        }
    }

    private void MoveToJoyStick()
    {
        transform.Translate(GameManager.instance.moveVec * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.PlayerDie(gameObject);
        Destroy(gameObject);
    }
}