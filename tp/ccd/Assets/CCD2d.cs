using UnityEngine;
using System.Collections;

public class CCD2d : MonoBehaviour {
	#region script_parameters
	// the end effector of the kinematic chain
	// In our case the last sphere on the hierrarchy
	public Transform effector;
	
	// the target we want the end-effector to reach
	// In our case the cube
	public Transform target;	
	#endregion script_parameters
	
	// the z vector around which the joints are rotated in 2d
	private Vector3 z = new Vector3(0,0,1);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CCDStep2D(effector.parent, effector, target);
	}
	
	
	/// \brief method for computing a signed angle value between two 2d vectors using
	/// their dot product. Signed is determined using the trigonometric direct way.
	/// for instance if we have a = new Vector2(1,0) and b = new Vector2(0,1)
	/// then ComputeAngle2D(a, b) = Pi / 2 and ComputeAngle2D(b, a) = -Pi / 2
	/// \return the value of the signed angle existing between a and b.
	private float ComputeAngle2D(Vector2 a, Vector2 b)
	{
		float theta = 0;
		if(a.magnitude > 0.01 && b.magnitude > 0.01)
		{
			a.Normalize(); b.Normalize();
			float dot = Vector3.Dot(a,b);
			if(dot > 0.9999) dot = 1;
			theta = Mathf.Acos(dot);
			float sign = a.x * b.y - a.y * b.x;
			sign = (sign != 0) ? sign / Mathf.Abs(sign) : 0;
			theta *= sign;
		}
		return theta;
	}
	
	/// \brief performs one step of the CCD algorithm in 2d. For each joint in the kinematic chain,
	/// we compute the signed angle theta = (effector.joint.target). Since unity transforms work in 3d,
	/// the coordinates have to be projected in 2d.
	/// We then apply the rotation theta around the z axis to drive 
	/// the effector towards the target.The method is recursive
	/// and calls itself by going up the joint hierarchy.
	/// \param joint the current joint that will be rotated towards the target.
	/// \param effector the end effector transform.
	/// \param target the transform containing the position we want the end-effector to reach.
	private void CCDStep2D(Transform joint, Transform effector, Transform target)
	{
		Vector3 a = effector.position - joint.position; 
		Vector3 b = target.position   - joint.position;
		float theta = ComputeAngle2D( new Vector2(a.x, a.y)
									, new Vector2(b.x, b.y));
		joint.RotateAround(z, theta);	
		if(joint.parent != null)
		{
			CCDStep2D(joint.parent, effector, target);
		}
	}	
}
