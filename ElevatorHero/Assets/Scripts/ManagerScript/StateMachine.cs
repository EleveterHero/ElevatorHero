
using System;
using System.Collections.Generic;
using System.Configuration;

/// <summary>
/// ステートマシン
/// </summary>
public class StateMachine<T>
{ 
    /// <summary>
    /// ステート
    /// </summary>
    private class State
    {
        private readonly Action mEnterAct;  // 開始時に呼び出されるデリゲート
        private readonly Action mUpdateAct; // 更新時に呼び出されるデリゲート
        private readonly Action mExitAct;   // 終了時に呼び出されるデリゲート

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public State(Action enterAct = null, Action updateAct = null, Action exitAct = null)
        {
            mEnterAct = enterAct ?? delegate { };
            mUpdateAct = updateAct ?? delegate { };
            mExitAct = exitAct ?? delegate { };
        }

        /// <summary>
        /// 開始します
        /// </summary>
        public void Enter()
        {

            mEnterAct();
        }

        /// <summary>
        /// 更新します
        /// </summary>
        public void Update()
        {

            mUpdateAct();
            
        }

        /// <summary>
        /// 終了します
        /// </summary>
        public void Exit()
        {

            mExitAct();
        }
    }

    private Dictionary<T, State> mStateTable = new Dictionary<T, State>();   // ステートのテーブル
    private State mCurrentState;                              // 現在のステート

    private T m_state_key;

    /// <summary>
    /// ステートを追加します
    /// </summary>
    public void Add(T key, Action enterAct = null, Action updateAct = null, Action exitAct = null)
    {
        mStateTable.Add(key, new State(enterAct, updateAct, exitAct));
    }

    /// <summary>
    /// 現在のステートを設定します
    /// </summary>
    public void SetState(T key)
    {

        if (mCurrentState != null)
        {
            mCurrentState.Exit();
        }
        m_state_key = key;
        mCurrentState = mStateTable[key];

        mCurrentState.Enter();

    }


    /// <summary>
    /// 現在のステートを更新します
    /// </summary>
    public void Update()
    {
        if (mCurrentState == null)
        {
            return;
        }
        mCurrentState.Update();
    }

    /// <summary>
    /// すべてのステートを削除します
    /// </summary>
    public void Clear()
    {
        mStateTable.Clear();
        mCurrentState = null;
    }

    /// <summary>
    /// 現在のステート名を返します
    /// </summary>
    public T GetStateName()
    {
        return m_state_key;
    }


}