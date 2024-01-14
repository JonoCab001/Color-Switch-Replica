using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public string currentColour;
    public Color colour_Cyan;
    public Color colour_Magentha;
    public Color colour_Pink;
    public Color colour_Yellow;
    //public Color[] colors;
    //public string[] colours = { "Cyan", "Magentha", "Pink", "Yellow" }; 

    void Start()
    {
        SetRandomColour();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log("Player Jumped");
        }
    }

    // This identifies on what colour has been touched on the colour wheel by the player
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider.tag);
        if (collider.tag == "ColourChanger")
        {
            SetRandomColour();
            Destroy(collider.gameObject);
            return;
        }
        
        if (collider.tag != currentColour)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // This will switch the colour of the player depending on what colour they touch on the wheel
    void SetRandomColour()
    {
        int index = Random.Range(0, 4);

        // These are heavy syntaxes
        //if (index == 0) // This will do one thing
        //else if (index == 1) // This will do one thing

        switch (index) 
        {
            case 0:
                currentColour = "Cyan";
                spriteRenderer.color = colour_Cyan;
                break;
            case 1:
                currentColour = "Magentha";
                spriteRenderer.color = colour_Magentha;
                break;
            case 2:
                currentColour = "Pink";
                spriteRenderer.color = colour_Pink;
                break;
            case 3:
                currentColour = "Yellow";
                spriteRenderer.color = colour_Yellow;
                break;
        }

        Debug.Log("Current colour of the player is: " +currentColour);
    }
}
