using UnityEngine;

public class Wall : MonoBehaviour
{
	public GameObject Web;
	public bool IsRightWall;
	public bool IsLeftWall;
	private void OnCollisionEnter(Collision collision)
	{
		SphereCollider ww = collision.gameObject.GetComponent<SphereCollider>();
		Debug.Log(collision.gameObject.name);
		if (collision.gameObject.CompareTag("Web"))
		{
			GameObject dd = Instantiate(Web, collision.gameObject.transform.position + new Vector3(0, 0, -0.4f), Quaternion.Euler(0, 180f, Random.Range(0, 360)));
			dd.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			if (IsRightWall)
			{
				dd.transform.rotation = Quaternion.Euler(dd.transform.rotation.eulerAngles + new Vector3(0, 90f, 0));
			}
			if (IsLeftWall)
			{
				dd.transform.rotation = Quaternion.Euler(dd.transform.rotation.eulerAngles + new Vector3(0, -90f, 0));
			}
		}
	}
}
