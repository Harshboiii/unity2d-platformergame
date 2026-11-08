using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int contacts = 0;
    public bool IsGrounded()
    {
        return contacts > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++contacts;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --contacts;
        
    }
}