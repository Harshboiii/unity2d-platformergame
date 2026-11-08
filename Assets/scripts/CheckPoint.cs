using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject inactiveState = null;
    [SerializeField]
    private GameObject activedState = null;

    private void Awake()
    {
        inactiveState.SetActive(true);
        activedState.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision!=null && collision.gameObject !=null)
        {
            inactiveState.SetActive(false);
            activedState.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
            CheckPointManager.Instance.SetHitCheckpoint(this);
        }
    }
}
