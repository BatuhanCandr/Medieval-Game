using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnim;


        internal void PlayerRunAnim()
        {
            playerAnim.SetBool("HorseRun",true);
        }
        internal void PlayerIdleAnim()
        {
            playerAnim.SetBool("HorseRun",false);
        }
    }  
}

