using UnityEngine;

public class BallerinaSocket : MonoBehaviour
{
    public Transform snapPoint;
    public float snapDistance = 0.15f;

    public bool ballerinaInserted = false;

    public void Update()
    {
        if (ballerinaInserted) return;

        GameObject ballerina = GameObject.FindGameObjectWithTag("Ballerina");
        if (ballerina == null) return;

        float distance = Vector3.Distance(ballerina.transform.position, snapPoint.position);

        if (distance <= snapDistance)
        {
            SnapBallerina(ballerina);
        }
    }

    private void SnapBallerina(GameObject ballerina)
    {
        ballerina.transform.position = snapPoint.position;
        ballerina.transform.rotation = snapPoint.rotation;

        Rigidbody rb = ballerina.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        ballerinaInserted = true;
	
	Behaviour [] comps = ballerina.GetComponents<Behaviour>();
	foreach (Behaviour b in comps)
		if(b.GetType().Name == "Grabbable" || b.GetType().Name == "HandGrabInteractable")
			b.enabled = false;
	

        MusicBoxInteractionManager manager = FindFirstObjectByType<MusicBoxInteractionManager>();
        if (manager != null)
        {
            manager.BallerinaInserted();
        }
    }
}