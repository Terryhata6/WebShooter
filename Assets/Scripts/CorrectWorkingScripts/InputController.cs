using UnityEngine;

public class InputController : MonoBehaviour
{
	//следит за пальцем на экране
	public Vector3 TouchPosition;
	public bool DragingStarted = false;
	public bool UseMouse = false;
	public Camera CameraForInput;
	private Touch touch;
	private WebShooter _webShooter;

	private void Start()
	{
		//CameraForInput = FindObjectOfType<Camera>();
		TouchPosition = new Vector3(0, 0);
		_webShooter = FindObjectOfType<WebShooter>();
	}

	private void Update()
	{
		if (!UseMouse)
		{
			if (Input.touchCount > 0)
			{
				touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
				{
					DragingStarted = true;
					TouchPosition = CameraForInput.ScreenToWorldPoint(touch.position);
					_webShooter.ShootWeb(TouchPosition);
				}
				else if (touch.phase == TouchPhase.Moved)
				{
					TouchPosition = CameraForInput.ScreenToWorldPoint(touch.position);
				}
			}
			else
			{
				DragingStarted = false;
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				DragingStarted = true;
				TouchPosition = CameraForInput.ScreenToWorldPoint(Input.mousePosition);
				_webShooter.ShootWeb(TouchPosition);
			}
			else
			{
				DragingStarted = false;
			}
		}
	}
}
