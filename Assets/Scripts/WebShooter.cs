using UnityEngine;

public class WebShooter : MonoBehaviour
{
	public float WebSpeed;
	public GameObject Web;
	public Animator RightHandAnimator;
	public Animator LeftHandAnimator;
	public Transform RightHandTransform;
	public Transform LeftHandTransform;
	public Vector3 RightHandPosition;
	public Vector3 LeftHandPosition;


	private GameObject WebObject;
	private WebContainer _webContainer;
	private Vector3 GoalPosition;
	private Vector3 ZVector;

	private void Start()
	{
		_webContainer = FindObjectOfType<WebContainer>();
		RightHandPosition = RightHandTransform.position;
		LeftHandPosition = LeftHandTransform.position; ZVector = new Vector3(0, 0, 12f);
	}
	public void ShootWeb(Vector3 PositionOfTouch)
	{
		if (_webContainer.CheckWeb())
		{
			_webContainer.DecreaseWebAmount();
			Destroy(WebObject);
			GoalPosition = PositionOfTouch + ZVector;
			GoalPosition.y = GoalPosition.y * 1.3f;
			GoalPosition.x = GoalPosition.x * 1.3f;
			if (PositionOfTouch.x > 0)
			{
				RightHandPosition = RightHandTransform.position;
				WebObject = Instantiate(Web, new Vector3(RightHandPosition.x, RightHandPosition.y, RightHandPosition.z), Quaternion.identity);
				RightHandAnimator.SetTrigger("Shoot");
			}
			else
			{
				LeftHandPosition = LeftHandTransform.position;
				WebObject = Instantiate(Web, new Vector3(LeftHandPosition.x, LeftHandPosition.y, LeftHandPosition.z), Quaternion.identity);
				LeftHandAnimator.SetTrigger("Shoot");
			}
		}
	}
	private void FixedUpdate()
	{
		MoveWeb();
	}
	private void MoveWeb()
	{
		if (WebObject != null)
		{
			WebObject.transform.position = Vector3.MoveTowards(WebObject.transform.position, GoalPosition, WebSpeed);
		}
	}
}
