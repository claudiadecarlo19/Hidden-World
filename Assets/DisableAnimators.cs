using UnityEngine;
using UnityEngine.Playables;

public class DisableAnimators : MonoBehaviour {

	public PlayableDirector timeline;
	public Animator ballerina;
	public Animator handle;

	void Update(){
		if(timeline.state != PlayState.Playing){
			ballerina.enabled = false;
			handle.enabled = false;
		}
	}
}