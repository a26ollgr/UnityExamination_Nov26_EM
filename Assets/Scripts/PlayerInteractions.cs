using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    private int coinsCollected = 0;
    public bool hasBall = false;
    
    private GameObject player;
    
    [SerializeField] private TMPro.TextMeshProUGUI coinsCollectedText;
    
    private GameObject interactingObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeBall()
    {
        hasBall = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.GetComponent<Interactable>() != null)
        {
            interactingObject = other.gameObject;
            Debug.Log(interactingObject.name);

            Debug.Log("Player entered the trigger zone of an interactable object.");

            if(other.GetComponent<Interactable>().PlayerInRange != null)
            {
                other.GetComponent<Interactable>().PlayerInRange.Invoke();
            }
        } else if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            coinsCollected++;
            coinsCollectedText.text = $"{coinsCollected}x";
            player.GetComponent<AudioSource>().Play();
        }
        
        

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Interactable>() != null)
        {

            interactingObject = null;

            Debug.Log("Player exited the trigger zone of an interactable object.");

            if (other.GetComponent<Interactable>().PlayerOutOfRange != null)
            {
                other.GetComponent<Interactable>().PlayerOutOfRange.Invoke();
            }

        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("interacting");
        }
        
        if(context.performed && interactingObject != null)
        {
            Debug.Log("Player interacted with an object.");
            if(interactingObject.GetComponent<Interactable>().PlayerInteracts != null)
            {
                interactingObject.GetComponent<Interactable>().PlayerInteracts.Invoke();
            }
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
