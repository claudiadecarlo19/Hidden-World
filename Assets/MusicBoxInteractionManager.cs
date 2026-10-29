using UnityEngine;
using UnityEngine.Playables;

public class MusicBoxInteractionManager : MonoBehaviour
{
    public HandleRotator handle;
    public PlayableDirector timeline;
    public GameObject key;

    public bool ballerinaReady = false;
    public bool handleReady = false;
    public bool timelineStarted = false;

    public void BallerinaInserted()
    {
        ballerinaReady = true;

        if (handle != null)
        {
            handle.Activate();
        }

        TryStartTimeline();
    }

    public void HandleCompleted()
    {
        handleReady = true;
        TryStartTimeline();
    }

    private void TryStartTimeline()
    {
        if (timelineStarted) return;

        if (ballerinaReady && handleReady)
        {
            timelineStarted = true;

            if (timeline != null)
            {
		GameObject handle = GameObject.FindGameObjectWithTag("Handle");
		GameObject ballerina = GameObject.FindGameObjectWithTag("Ballerina");

		Behaviour [] compsH = handle.GetComponents<Behaviour>();
		foreach (Behaviour b in compsH)
		if(b.GetType().Name == "Animator")
			b.enabled = true;
		Behaviour [] compsB = ballerina.GetComponents<Behaviour>();
		foreach (Behaviour b in compsB)
		if(b.GetType().Name == "Animator")
			b.enabled = true;

                timeline.Play();

            }
        }
    }
}