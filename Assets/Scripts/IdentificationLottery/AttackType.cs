using UnityEngine;

namespace Assets.Scripts.IdentificationLottery
{
    public class AttackType : MonoBehaviour
    {
        public Animator Animator;

        public void StartAttacking()
        {
            Animator.SetBool("attacking", true);
        }

        public void StopAttacking()
        {
            Animator.SetBool("attacking", false);
        }
    }
}