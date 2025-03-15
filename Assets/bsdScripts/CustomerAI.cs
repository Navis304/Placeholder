using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public bool rid = false;
    public NavMeshAgent customerAI;
    public Animator anim;
    public string state = "idle";
    public Queue queueS;
    public int currentPosInQueue;
    private Transform player;
    public Transform awayFromMap;
    public bool isSpecial;
    private void Awake()
    {
        customerAI = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        queueS = GameObject.Find("Q").GetComponent<Queue>();
        awayFromMap = GameObject.Find("AwayFromMap").GetComponent<Transform>();
        Invoke("AwakeDel", Random.Range(0.1f, 0.3f));
    }
    private void Update()
    {
        if (rid)
        {
            RidOfCustomerFromQueue();
        }
        if (state == "idle")
        {
            Invoke("UpdateDel", Random.Range(0.1f, 0.3f));
        }
        if (state == "walk")
        {
            if (customerAI.remainingDistance <= customerAI.stoppingDistance && !customerAI.pathPending)
            {
                anim.SetBool("cS", false);
                state = "idle";
            }
        }
        if(state == "getOut")
        {
            if(Vector3.Distance(this.gameObject.transform.position,player.position) > 30f)
            {
                Destroy(this.gameObject);
            }
        }

    }
    public void RidOfCustomerFromQueue()
    {
        queueS.isQueueAviable[currentPosInQueue] = false;
        customerAI.SetDestination(awayFromMap.position);
        state = "getOut";
    }
    public void AwakeDel()
    {
        for (int z = 0; z < queueS.queue.Length; z++)
        {
            if (!queueS.isQueueAviable[z])
            {
                queueS.isQueueAviable[z] = true;
                currentPosInQueue = z;
                customerAI.SetDestination(queueS.queue[z].position);
                anim.SetBool("cS", true);
                state = "walk";
                break;
            }
        }
    }
    public void UpdateDel()
    {
        if (currentPosInQueue != 0)
        {
            if (!queueS.isQueueAviable[currentPosInQueue - 1])
            {
                queueS.isQueueAviable[currentPosInQueue - 1] = true;
                queueS.isQueueAviable[currentPosInQueue] = false;
                currentPosInQueue--;
                customerAI.SetDestination(queueS.queue[currentPosInQueue].position);
                anim.SetBool("cS", true);
                state = "walk";
            }
        }
    }
}
