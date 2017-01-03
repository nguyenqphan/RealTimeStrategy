using UnityEngine;
using System.Collections;

public class RightClickNavigation : Interaction {


	public float RelaxDistance = 5f;


	private NavMeshAgent agent;
	private Vector3 target = Vector3.zero;

	private bool selected = false;
	private bool isActive = false;			//being selected

	public override void Deselect()
	{
		selected = false;
	}

	public override void Select()
	{
		selected = true;
	}

	//move the player to the destination
	public void SendToTarget()
	{
		agent.SetDestination(target);
		agent.Resume();
		isActive = true;
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(selected && Input.GetMouseButtonDown(1))
		{
			var temTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
			if(temTarget.HasValue)
			{
				target = temTarget.Value;
				SendToTarget();
			}
		}

		if(isActive && Vector3.Distance(target, transform.position) < RelaxDistance)
		{
			agent.Stop();
			isActive = false;
		}
	}


}
