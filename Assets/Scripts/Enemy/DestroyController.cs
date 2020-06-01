using System.Linq;
using UnityEngine;

public class DestroyController : StateMachineBehaviour
{
  //  public GameObject toDestroy;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var parent = animator.GetComponentsInParent<Transform>().FirstOrDefault();
       // if (parent != null)
            Destroy(parent.gameObject, stateInfo.length);
    }
}
