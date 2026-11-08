using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private CheckPoint lastSavedCheckpoint = null;
    private static CheckPointManager instance;
    public static CheckPointManager Instance { get { return instance; } }
    private void Awake()
    {         if (instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetHitCheckpoint(CheckPoint checkpoint)
    {
        lastSavedCheckpoint = checkpoint;
    }
    public bool TryGetLastCheckpointPosition(out Vector3 checkpointPosition)
    {
        checkpointPosition = Vector3.zero;
        if (lastSavedCheckpoint == null)
        {
            
            return false;
        }
       checkpointPosition = lastSavedCheckpoint.transform.position;
        return true;
    }
} 

