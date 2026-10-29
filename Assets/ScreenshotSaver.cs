using UnityEngine;
using System.Collections;

// Simple screenshot saver for FIT3169

/* Usage:
	- Drag this script into your Unity project, and apply it to your camera.
 		- Use the "Add Component" button in the Inspector and search for this script.
 	- Any time the '0' key is pressed, a screenshot will save into your project folder.
		- Navigate to your project in Explorer or Finder and the screenshots will be next to the assets folder.
 */

public class ScreenshotSaver : MonoBehaviour {

	public KeyCode captureKey = KeyCode.Alpha0;
	public int upscaleFactor = 1;
	private int screenshotCount = 0;
	
	void Update()
	{
		if (Application.isEditor && Input.GetKeyDown(captureKey))
		{        
			string screenshotFilename;
			do
			{
				// Increment suffix so we don't overwrite an existing image
				screenshotCount++;
				screenshotFilename = "Screenshot " + screenshotCount + ".png";
				
			} while (System.IO.File.Exists(screenshotFilename));
			
			ScreenCapture.CaptureScreenshot(screenshotFilename, upscaleFactor);
		}
	}
}
