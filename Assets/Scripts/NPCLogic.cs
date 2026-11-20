using UnityEngine;

public class NPCLogic : MonoBehaviour
{

    [SerializeField] private GameObject interactPrompt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerEnter()
    {
        
        interactPrompt.SetActive(true);
        
    }
    public void PlayerExit()
    {
        
        interactPrompt.SetActive(false);
        
    }
}
