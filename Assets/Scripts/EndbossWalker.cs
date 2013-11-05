using UnityEngine;
using System.Collections;

public class EndbossWalker : WaypointWalker {
	
	protected override void ApplyDamage (int damage)
	{
		base.ApplyDamage (damage);
		currentWaypoint = 0;
	}
	
	protected override void Move ()
	{
		if (!isHit)
			base.Move ();
	}
}
