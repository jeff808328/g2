using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongHairStateManager : MonoBehaviour
{
    #region State

    private LongHairBaseState CurrentState;

    public LongHairIdle Idle = new LongHairIdle();
    public LongHairWalk Walk = new LongHairWalk();
    public LongHairDash Dash = new LongHairDash();
    public LongHairAttack Attack = new LongHairAttack();
    public LongHairSingleThron SingleThron = new LongHairSingleThron();

    public LongHairMultipleThron MultipleThron = new LongHairMultipleThron();
    public LongHairAirUmi AirUmi = new LongHairAirUmi();
    public LongHairGroundUmi GroundUmi = new LongHairGroundUmi();
    public LongHairHurt Hurt = new LongHairHurt();

    #endregion

    #region Component

    [HideInInspector] public EnemyBackGroundData EnemyBackGroundData;
    [HideInInspector] public EnemyMove EnemyMove;
    [HideInInspector] public GroundAndWallDetect GroundAndWallDetect;
    [HideInInspector] public EnemyAttack EnemyAttack;
    [HideInInspector] public CommonAnimator CommonAnimator;
    [HideInInspector] public CommonHP CommonHP;

    #endregion

    #region Value
    public int MoveDirection; // ���ʴ¦V

    [HideInInspector] public float LastFlipTime;
    public float FlipCD; // ½�ඡ�j 

    [HideInInspector] public float LastAttackTime;
    public float AttackCD; // �������j 

    [HideInInspector] public float LastStateSwitchTime;
    public float StateTransDelay; // �i�J�U�Ӫ��A������

    [HideInInspector] public int SkillUsedTime;
    #endregion

    private void Start()
    {
        ComponentSetting();

        InitSetting();

        CurrentState = Idle;
        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void StateSwitch(LongHairBaseState NextState)
    {
        CurrentState = NextState;
        NextState.EnterState(this);
    }

    private void InitSetting()
    {
        LastFlipTime = Time.time;
        LastAttackTime = Time.time;
        LastStateSwitchTime = Time.time;
    }

    private void ComponentSetting()
    {
        EnemyBackGroundData = this.GetComponent<EnemyBackGroundData>();
        EnemyMove = this.GetComponent<EnemyMove>();
        GroundAndWallDetect = this.GetComponent<GroundAndWallDetect>();
        EnemyAttack = this.GetComponent<EnemyAttack>();
        CommonAnimator = this.GetComponent<CommonAnimator>();
    }

}