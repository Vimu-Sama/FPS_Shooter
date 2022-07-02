using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] List<AnimationClip> animationClips= new List<AnimationClip>();
    Animator anim;
    public void changeAnimation(animationstates anime)
    {
        if(anime== animationstates.idle)
        {
            anim.Play("") ;
        }

    }


}
