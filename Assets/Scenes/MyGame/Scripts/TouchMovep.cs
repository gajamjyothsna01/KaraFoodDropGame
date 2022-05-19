using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchMovep: MonoBehaviour
{
    #region PUBLIC VARIABLES
    public float moveSpeed;
    public Text healthText;
    #endregion
    int playerLives = 3;
    #region MONOBEHAVIOUR METHODS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchMovePlayer();
    }
    #endregion

    #region PRIVATE METHODS

    private void TouchMovePlayer()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Getting access of the Mouse position where we have touched
            
            if(mousePosition.x > 1)
            {
                //move right
                transform.Translate(moveSpeed*Time.deltaTime,0,0);
            }
            else if(mousePosition.x <1)
            {
                // move left
                transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);

            }
            else if (mousePosition.x ==0)
            {
                transform.Translate(0, 0, 0);
            }


            //Restrcting the Value of the Player position
            if (transform.position.x > 9.5f)
            {
                transform.position = new Vector3(9.5f, transform.position.y, 0);

            }
            if (transform.position.x < -9.5f)
            {

                transform.position = new Vector3(-9.5f, transform.position.y, 0);
            }



        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Debug.Log("Its collided");
            collision.gameObject.SetActive(false);
            GameObject.Find("ScoreManager").GetComponent<ScoreManagerScript>().Score(10);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            playerLives--;
            Debug.Log("Player Health " +playerLives);
            collision.gameObject.SetActive(false);  
            healthText.text = playerLives.ToString();

            if(playerLives == 0)
            {
                Debug.Log("Player is dead");
                this.gameObject.SetActive(false);

            }

        }
    }
    #endregion
}
