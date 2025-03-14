using UnityEngine;

public class Queue : MonoBehaviour
{
    public Transform[] queue;
    public bool[] isQueueAviable;
    private void Awake()
    {
        queue = this.gameObject.GetComponentsInChildren<Transform>();
    }
}
