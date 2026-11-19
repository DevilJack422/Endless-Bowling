using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float groundLength;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the ground piece forward by the length of the ground to create an infinite scrolling effect
            transform.parent.position += new Vector3(0, 0, groundLength * 2);
        }
    }
}
