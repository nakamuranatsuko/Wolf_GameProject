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
    /// �T���Q�Ă���Ƃ��̃A�j���[�V����
    /// </summary>
    public void WolfIdleAnimation()
    {
        //�A�j���[�V������~
        spineAnimationState.ClearTrack((int)WolfAnimatonName.Eye_Full);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.MIX);

        //�A�j���[�V�����Đ�
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.Close_idle, WolfAnimatonName.Close_idle.ToString(), true);
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.Idle, WolfAnimatonName.Idle.ToString(), true).MixDuration = 0.5f;
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.tailAnimation, WolfAnimatonName.tailAnimation.ToString(), true).MixDuration = 0.5f;
    }

    /// <summary>
    /// �T���N�������̃A�j���[�V����
    /// </summary>
    public void WolfActiveAnimation()
    {
        //�A�j���[�V������~
        spineAnimationState.ClearTrack((int)WolfAnimatonName.Close_idle);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.MIX);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.tailAnimation);
        spineAnimationState.ClearTrack((int)WolfAnimatonName.Idle);

        //�A�j���[�V�����Đ�
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.Eye_Full, WolfAnimatonName.Eye_Full.ToString(), true);
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.MIX, WolfAnimatonName.MIX.ToString(), true).MixDuration = 0.5f;
        spineAnimationState.SetAnimation
            ((int)WolfAnimatonName.tailAnimation, WolfAnimatonName.tailAnimation.ToString(), true).MixDuration = 0.5f;
    }
}
