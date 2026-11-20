using UnityEngine;

public class CreateObject : MonoBehaviour
{
    
    [SerializeField] private GameObject obj;

    public void Create()
    {
        Vector3 position = new  Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        
        if (obj != null)
        {
            Instantiate(obj, position, transform.rotation);   
        }
    }
    
}
