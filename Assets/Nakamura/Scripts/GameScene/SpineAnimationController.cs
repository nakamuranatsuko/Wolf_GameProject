using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimationController : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;
    private Spine.AnimationState spineAnimationState;

    private enum WolfAnimatonName
    {
        BreathAnimation = 0,
        Close_idle = 1,
        Eye_Full = 2,
        Idle = 4,
        MIX = 5,
        tailAnimation = 6
    }

    void Start()
    {
        spineAnimationState = skeletonAnimation.AnimationState;
    }

    /// <summary>
    /// 狼が寝ているときのアニメーション
    /// </summary>
    public void WolfIdleAnimation()
    {
        //アニメーション停止
        spineAnimationState.ClearTrack((int)WolfAnimatonName.Eye_Full);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.MIX);

        //アニメーション再生
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.Close_idle, WolfAnimatonName.Close_idle.ToString(), true);
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.Idle, WolfAnimatonName.Idle.ToString(), true).MixDuration = 0.5f;
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.tailAnimation, WolfAnimatonName.tailAnimation.ToString(), true).MixDuration = 0.5f;
    }

    /// <summary>
    /// 狼が起きた時のアニメーション
    /// </summary>
    public void WolfActiveAnimation()
    {
        //アニメーション停止
        spineAnimationState.ClearTrack((int)WolfAnimatonName.Close_idle);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.MIX);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.tailAnimation);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.Idle);

        //アニメーション再生
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.Eye_Full, WolfAnimatonName.Eye_Full.ToString(), true);
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.MIX, WolfAnimatonName.MIX.ToString(), true).MixDuration = 0.5f;
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.tailAnimation, WolfAnimatonName.tailAnimation.ToString(), true).MixDuration = 0.5f;
    }
}
