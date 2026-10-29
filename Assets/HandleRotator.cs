using UnityEngine;

public class HandleRotator : MonoBehaviour
{
    public bool canRotate = false;

    public MusicBoxInteractionManager manager;

    public float triggerAngle = 120f;

    public bool triggered = false;
	public Transform rotatingPart;

    public void Activate()
    {
        canRotate = true;
	
	GameObject handle = GameObject.FindGameObjectWithTag("Handle");
	if(handle == null) return;

	Behaviour [] comps = handle.GetComponents<Behaviour>();
	foreach (Behaviour b in comps)
		if(b.GetType().Name == "Grabbable" || b.GetType().Name == "HandGrabInteractable")
			b.enabled = true;
    }

    void Update()
    {
        if (!canRotate) return;
	if (triggered) return;

        float angle = rotatingPart.localEulerAngles.y;

        if (angle > 180f)
            angle -= 360f;

        if (angle >= triggerAngle)
        {
            triggered = true;
            manager.HandleCompleted();
        }
    }
}

