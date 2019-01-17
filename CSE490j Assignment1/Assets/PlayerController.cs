using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public float rotationSpeed;
    public Text gameOver;
    public Text text;
    private int count;

    private Rigidbody rb;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        text.text = "Item Count: " + count; 
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        if (count == 12)
            gameOver.gameObject.SetActive(true);

    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count++;
            text.text = "Item Count: " + count;
            other.gameObject.SetActive(false);
        }
    }
}