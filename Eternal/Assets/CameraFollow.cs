using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player; 
    public float smoothing = 5f;
    
    private Vector3 offset; 

    void Start()
    {
        
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            
            Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
