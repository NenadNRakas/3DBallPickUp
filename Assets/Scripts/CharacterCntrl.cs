// Add required Namespace
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterCntrl : MonoBehaviour
{
    // Public Variable available from with in Unity Editor
    public float velocity;
    public Text counterTxtTMP;
    public Text victoryTxt;
    // Private Variables local to the script
    private Rigidbody rB;
    private int counter;
    void Start()
    {
        // Find the local RigidBody Component
        rB = GetComponent<Rigidbody>();
        // Initialize the Counter Variable
        counter = 0;
        // Call the text function - Must be after variable initialization
        SetCounterText();
        // Initialize the empty text variable
        victoryTxt.text = "";
    }
    // Called before every physics calculation like moving a ball around
    void FixedUpdate()
    {
        // Controll Variables
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        // Apply the Force
        rB.AddForce(move * velocity);
    }
    void OnTriggerEnter(Collider other)
    {
        // Identify the Object
        if(other.gameObject.CompareTag("PickUpTag"))
        {
            // Deactivate PickUp on Collition
            other.gameObject.SetActive(false);
            // Increment the Counter
            counter = counter + 1;
            // Refresh the Counter Display with a function call
            SetCounterText();
        }
    }
    // Single function to call
    void SetCounterText()
    {
        // Display the UI counter
        counterTxtTMP.text = "Collected: " + counter.ToString();
        // Set the condition for text trigger
        if(counter >= 17)
        {
            victoryTxt.text = "That's all folks [;-]";
        }
    }
}
