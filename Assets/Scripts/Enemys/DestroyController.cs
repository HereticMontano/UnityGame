using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyController : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var parent = animator.GetComponentsInParent<Transform>().FirstOrDefault(x => x.tag == "Enemy");
        if (parent != null)
            Destroy(parent.gameObject, stateInfo.length);
    }
}
