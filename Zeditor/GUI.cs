using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Drawing;
using System.Timers;
using SoulsFormats.ESD;
using System.Text.RegularExpressions;
using SoulsFormats.ESD.EzSemble;

namespace Zeditor
{
    public partial class GUI : Form
    {
        public static EzSembleContext ScriptingContext = new EzSembleContext()
        {
            CommandNamesByID = new Dictionary<(int Bank, int ID), string>
            {
                {(1, 0), "ChangeGeneralAnim" },
                {(1, 1), "ChangeUpperBodyAnim" },
                {(1, 2), "ChangeStayAnim" },
                {(1, 3), "ChangeGeneralAnimCategorized" },
                {(1, 4), "ChangeUpperBodyAnimCategorized" },
                {(1, 5), "ChangeGeneralAnimAdditiveCategorized" },
                {(1, 6), "ChangeUpperBodyAnimAdditiveCategorized" },
                {(1, 7), "ChangeGeneralAnimCategorizedMatchPlaybackTime" },
                {(1, 8), "ChangeUpperBodyAnimCategorizedMatchPlaybackTime" },
                {(1, 9), "SetAnimIDOffset" },
                {(1, 10), "SetAdditiveBlendAnimation" },
                {(1, 11), "SetAdditiveBlendAnimationSlotted" },
                {(1, 12), "ChangeBlendAnimationCategorized" },
                {(1, 13), "ChangeUpperAndLowerBodySyncedAnimCategorized" },
                {(1, 100), "SwitchActiveActionState" },
                {(1, 101), "SwitchMotion" },
                {(1, 102), "SetThrowAttackTypePossible" },
                {(1, 103), "SetThrowDefenseTypePossible" },
                {(1, 104), "SwitchEquippedWeapon" },
                {(1, 105), "SetReadyForAtkFinish" },
                {(1, 106), "SetEquipmentChangeable" },
                {(1, 107), "SetUnableToDrop" },
                {(1, 108), "IssueMessageIDToEvents" },
                {(1, 109), "SetAttackType" },
                {(1, 110), "SetNoStaminaRecover" },
                {(1, 111), "Command111" },
                {(1, 112), "SetAIBusyDoingAction" },
                {(1, 113), "BowTurn" },
                {(1, 114), "SetIsHoldingBow" },
                {(1, 115), "SwitchSpecificRangeMode" },
                {(1, 116), "SwitchSpecialMotion" },
                {(1, 117), "SetIsWeaponChanging" },
                {(1, 118), "SetIsItemInUse" },
                {(1, 119), "SetIsItemAnimPlaying" },
                {(1, 120), "RemoveBinoculars" },
                {(1, 121), "SetIsMagicInUse" },
                {(1, 122), "IsHeadTurnPossible" },
                {(1, 123), "ChangeHoveringState" },
                {(1, 124), "ChangeToSpecialStandby" },
                {(1, 125), "OpenMenuWhenUsingItem" },
                {(1, 126), "OpenMenuWhenUsingMagic" },
                {(1, 127), "BlowDamageTurn" },
                {(1, 128), "SetDeathStandby" },
                {(1, 129), "CloseMenuWhenUsingItem" },
                {(1, 130), "CloseMenuWhenUsingMagic" },
                {(1, 131), "AdditionNoTurning" },
                {(1, 132), "WhiffPossibility" },
                {(1, 133), "ChangeFlightStatus" },
                {(1, 134), "SetStatsNotMetAnimID" },
                {(1, 135), "ShowFixedYAxisDirectionDisplay" },
                {(1, 136), "SetLadderActionState" },
                {(1, 137), "ForceCancelThrowAnim" },
                {(1, 138), "SetThrowState" },
                {(1, 139), "LadderSlideStart" },
                {(1, 140), "SetIsEventActionPossible" },
                {(1, 141), "RequestThrowAnimInterrupt" },
                {(1, 142), "SetHandStateOfLadder" },
                {(1, 143), "SetDamageAnimType" },
                {(1, 144), "SlideTurn" },
                {(1, 145), "InterruptAttack" },
                {(1, 146), "MidairDeathWarp" },
                {(1, 147), "ClearSlopeInfo" },
                {(1, 148), "StateInputRecieve" },
                {(1, 149), "EquipmentChangeableFromMenu" },
                {(1, 200), "SetVariable" },
                {(1, 151), "AimAtSelfPosition" },
                {(1, 152), "StateIdentifier" },
                {(1, 153), "DoAIReplanningAtCancelTiming" },
                {(1, 154), "DenyEventAnimPlaybackDemand" },
                {(1, 155), "InvokeBackstab" },
                {(1, 156), "WeaponParamReferent" },
                {(1, 157), "AINotifyAttackType" },
                {(1, 158), "SetAutoTrapTarget" },
                {(1, 159), "ClearAutoTrapTarget" },
                {(1, 1000), "AddHP" },
                {(1, 1001), "AddStamina" },
                {(1, 1100), "SyncAtInit_Active" },
                {(1, 1101), "SyncAtInit_Passive" },
                {(1, 2000), "SetIsTurnAnimInProgress" },
                {(1, 2001), "CalculateTurnAnimCorrectionFactor" },
                {(1, 2002), "SetStealthState" },
                {(1, 2003), "SetMoveMult" },
                {(1, 2004), "SpEffectAccomodation" },
                {(1, 2005), "StealthyHighSpeedThrowEffective" },
                {(1, 2006), "SetTurnSpeed" },
                {(1, 2007), "SetCeremonyState" },
                {(1, 2008), "SetDamageMotionBlendRatio" },
                {(1, 2009), "SetForceTurnTarget" },
                {(1, 2010), "InSpecialGuard" },
                {(1, 2011), "SetWeaponCancelType" },
                {(1, 2012), "IsPreciseShootingPossible" },
                {(1, 2013), "ChooseBowAndArrowSlot" },
                {(1, 2014), "Set4DirectionMovementThreshold" },
                {(1, 2015), "LockonSystemUnableToTurnAngle" },
                {(1, 2016), "ReserveArtsPointsUse" },
                {(1, 2017), "SetArtsPointFEDisplayState" },
                {(1, 2018), "LockonFixedAngleCancel" },
                {(1, 2019), "TurnToLockonTargetImmediately" },
                {(1, 2020), "SetSpecialInterpolation" },
                {(1, 2021), "LadderSlideDownCancel" },
                {(1, 2022), "DisableMagicIDSwitching" },
                {(1, 2023), "DisableToolIDSwitching" },
                {(1, 9000), "DebugLogOutput" },
                {(1, 9001), "Test_SpEffectDelete" },
                {(1, 9002), "Test_SpEffectTypeSpecifyDelete" },
                {(1, 9100), "Function9100" },
                {(1, 9101), "RequestAIReprogramming" },
                {(1, 9102), "MarkOfGreedyPersonSlipDamageDisable" },
                {(1, 9103), "ResetInputQueue" },
                {(1, 9104), "SetIsEventAnim" },
                {(1, 9105), "AIAttackState" },
            },
                    FunctionNamesByID = new Dictionary<int, string>
            {
                { 0, "IsGeneralAnimEnd" },
                { 1, "IsAttackAnimEnd" },
                { 9, "AnimIDOffset" },
                { 10, "AdditiveBlendAnim" },
                { 11, "AdditiveBlendAnimOfSlot" },
                { 100, "IsAtkRequest" },
                { 101, "IsAtkReleaseRequest" },
                { 102, "IsChainAtkRequest" },
                { 103, "GetAtkDuration" },
                { 104, "GetWeaponSwitchRequest" },
                { 105, "GetCommandIDFromEvent" },
                { 106, "GetAIActionType" },
                { 107, "GetAIChainActionType" },
                { 108, "GetChainEvadeRequest" },
                { 109, "GetWeaponChangeRequest" },
                { 110, "GetAnimIDFromMoveParam" },
                { 111, "IsThereAnyAtkRequest" },
                { 112, "IsThereAnyChainAtkRequest" },
                { 113, "IsItemUseMenuOpening" },
                { 114, "IsMagicUseMenuOpening" },
                { 115, "IsItemUseMenuOpened" },
                { 116, "IsMagicUseMenuOpened" },
                { 117, "GetBlendAnimIDFromMoveParam" },
                { 118, "GetAIChainStepType" },
                { 119, "GetTransitionToSpecialStayAnimID" },
                { 120, "GetAIAtkCancelType" },
                { 121, "GetWeaponCancelType" },
                { 122, "IsWeaponCancelPossible" },
                { 123, "GetAIDefenseCancelType" },
                { 124, "GetAIVersusBackstabCancelType" },
                { 200, "IsFalling" },
                { 201, "IsLanding" },
                { 202, "GetReceivedDamageType" },
                { 203, "IsActiveActionValid" },
                { 204, "GetActionEventNumber" },
                { 205, "IsNormalDmgPassThroughDuringThrow" },
                { 206, "IsThrowing" },
                { 207, "GetWeaponSwitchState" },
                { 209, "IsEquipmentSwitchPossible" },
                { 210, "IsAnimCancelPossibleInAtkRelease" },
                { 211, "IsEmergencyStopAnimPlaying" },
                { 212, "GetLockRangeState" },
                { 213, "GetLockAngleState" },
                { 214, "IsAnimCancelPossibleInDamageHit" },
                { 215, "IsChangeToScrapeAtk" },
                { 216, "IsChangeToDeflectAtk" },
                { 217, "IsChangeToAfterParrySuccess" },
                { 218, "IsChangeFromNormalToBigAtk" },
                { 219, "GetMovementType" },
                { 220, "IsLargeAtkComboPossible" },
                { 221, "IsMapActionPossible" },
                { 222, "GetReceivedDamageDirection" },
                { 223, "GetMapActionID" },
                { 224, "GetFallHeight" },
                { 225, "GetEquipWeaponCategory" },
                { 226, "IsHoldingBow" },
                { 227, "GetMagicAnimType" },
                { 228, "WasNotLargeAtk" },
                { 229, "IsBackAtkPossible" },
                { 230, "IsAfterParryAtkPossible" },
                { 231, "GetItemAnimType" },
                { 232, "IsMagicUseable" },
                { 233, "IsItemUseable" },
                { 234, "IsPrecisionShoot" },
                { 235, "IsFireDamaged" },
                { 236, "GetDamageLevel" },
                { 237, "GetGuardLevelAction" },
                { 238, "IsNewLeftHandAtkValidFromStay" },
                { 239, "IsParryAtkValidFromStay" },
                { 240, "IsGuardValidFromStay" },
                { 241, "IsNewLeftHandAtkValidFromAtkCancel" },
                { 242, "IsParryAtkValidFromAtkCancel" },
                { 243, "IsGuardValidFromAtkCancel" },
                { 244, "IsTiedUp" },
                { 245, "IsOutOfArrows" },
                { 246, "IsUseCatLanding" },
                { 247, "GetHoverMoveState" },
                { 248, "IsTruelyLanding" },
                { 249, "IsRightHandMagic" },
                { 250, "IsChangeToSpecialStayAnim" },
                { 251, "GetSpecialStayAnimID" },
                { 252, "AcquireSpecialDamageAnimationID" },
                { 253, "IsRunTurnAnimPlaying" },
                { 254, "IsGenerateAction" },
                { 255, "GetSpecialStayCancelAnimID" },
                { 256, "HasReceivedAnyDamage" },
                { 257, "GetMoveAnimParamID" },
                { 258, "GetGuardLevel" },
                { 259, "IsRequestTurnAnimStart" },
                { 260, "IsTurningWithAnim" },
                { 261, "IsFlying" },
                { 262, "IsAbilityInsufficient" },
                { 263, "GetEquipWeightRatioForFalling" },
                { 264, "GetFlightMotionState" },
                { 265, "GetIsWeakPoint" },
                { 266, "GetMoveAnimBlendRatio" },
                { 267, "GetLadderActionState" },
                { 268, "IsInDisguise" },
                { 269, "IsCoopWait" },
                { 270, "IsCoop" },
                { 271, "IsSpecialTransitionPossible" },
                { 272, "GetLandingAnimBlendRatio" },
                { 273, "GetThrowAnimID" },
                { 274, "DidOpponentDieFromThrow" },
                { 275, "HasThrowEnded" },
                { 276, "IsThrowSelfDeath" },
                { 277, "IsThrowSuccess" },
                { 278, "GetGuardMotionCategory" },
                { 279, "IsBeingThrown" },
                { 280, "IsSelfThrow" },
                { 281, "IsThrowDeathState" },
                { 282, "GetNewLockState" },
                { 283, "IsOnLadder" },
                { 284, "GetPhysicalAttribute" },
                { 285, "GetSpecialAttribute" },
                { 286, "GetSpecialStayDeathAnimID" },
                { 287, "HasReceivedAnyDamage_AnimEnd" },
                { 288, "EggGrowth_IsHeadScratch" },
                { 289, "EggGrowth_IsBecomeEggHead" },
                { 290, "IsStop" },
                { 291, "IsSomeoneOnLadder" },
                { 292, "IsSomeoneUnderLadder" },
                { 293, "GetLadderHandState" },
                { 294, "DoesLadderHaveCharacters" },
                { 295, "IsLadderRightHandStayState" },
                { 296, "DescendingToFloor" },
                { 297, "IsInputDirectionMatch" },
                { 298, "IsSpecialTransition2Possible" },
                { 299, "IsVersusDivineDamage" },
                { 300, "IsGeneralAnimCancelPossible" },
                { 301, "GetEventEzStateFlag" },
                { 302, "IsLadderEventEnd" },
                { 303, "IsReachBottomOfLadder" },
                { 304, "IsReachTopOfLadder" },
                { 305, "GetStateChangeType" },
                { 306, "IsOnLastRungOfLadder" },
                { 311, "GetWeaponDurability" },
                { 312, "IsWeaponBroken" },
                { 313, "IsAnimEndBySkillCancel" },
                { 314, "EggGrowth_IsBecomeEgghead_SecondStage" },
                { 315, "IsHamariFallDeath" },
                { 316, "IsClient" },
                { 317, "IsSlope" },
                { 318, "IsSwitchState" },
                { 319, "IsPressUpKey" },
                { 320, "IsSpecialTurning" },
                { 321, "GetIntValueForTest" },
                { 322, "IsObjActInterpolatedMotion" },
                { 323, "GetObjActTargetDirection" },
                { 324, "GetObjActRemainingInterpolateTime" },
                { 325, "IsGap" },
                { 326, "GetWeaponID" },
                { 327, "IsMovingLaterally" },
                { 328, "IsNet" },
                { 329, "HasBrokenSA" },
                { 330, "IsEmergencyQuickTurnActivated" },
                { 331, "IsDoubleChantPossible" },
                { 332, "IsAnimOver" },
                { 333, "ObtainedDT" },
                { 334, "GetBehaviorID" },
                { 335, "IsTwoHandPossible" },
                { 336, "IsPartDamageAdditiveBlendInvalid" },
                { 337, "IsThrowPosRealign" },
                { 338, "GetBoltLoadingState" },
                { 339, "IsAnimEnd" },
                { 340, "IsTwinSwords" },
                { 341, "遅延旋回用TurnAngle取得" },
                { 342, "投げ抜け抵抗回数取得" },
                { 343, "緊急回避可能か" },
                { 344, "アーツポイント足りるか" },
                { 345, "装備武器特殊カテゴリ番号取得" },
                { 346, "イベントアニメ再生要求があるか" },
                { 347, "女性か" },
                { 348, "遅延旋回角度差取得" },
                { 349, "ダメージモーション無効か" },
                { 350, "武器能力開放ステータス値到達か" },
                { 351, "上腕制御外側角度" },
                { 352, "上腕制御上下角度" },
                { 353, "はしご滑り降り完了" },
                { 354, "はしご段数取得" },
                { 355, "滑り降り停止先のはしご段数取得" },
                { 356, "弓矢スロット取得" },
                { 357, "武器格納場所タイプ取得" },
                { 358, "待機アニメカテゴリ取得" },
                { 359, "GetWeaponSwitchStateDS3" },
                { 360, "装備メニュー開いているか" },
                { 361, "矢の残弾数取得" },
                { 1000, "GetHP" },
                { 1001, "GetStamina" },
                { 1002, "IsGhost" },
                { 1003, "GetRandomInt" },
                { 1004, "GetRandomFloat" },
                { 1005, "IsUnableToDie" },
                { 1006, "IsResurrectionPossible" },
                { 1007, "IsCOMPlayer" },
                { 1008, "GetAITargetAwareState" },
                { 1009, "IsAIChangeToAwareState" },
                { 1010, "GetAITargetAwareStatePreviousFrame" },
                { 1100, "GetTestDamageAnimID" },
                { 1101, "IsInvincibleDebugMode" },
                { 1102, "WasGameLaunchedInPGTestMode" },
                { 1103, "IsTiltingStick" },
                { 1104, "GetGestureRequestNumber" },
                { 1105, "待機ステートか" },
                { 1106, "アクションリクエスト" },
                { 1107, "アクション解除リクエスト" },
                { 1108, "アクション継続時間" },
                { 1109, "何かアクションリクエストがあるか" },
                { 1110, "移動リクエスト" },
                { 1111, "移動リクエスト継続時間" },
                { 1112, "投げ要求か" },
                { 1113, "ガードキャンセル可能か" },
                { 1114, "アニメが存在するか" },
                { 1115, "AI移動タイプ取得" },
                { 1116, "特殊効果IDを取得" },
                { 1117, "会話が終了したか" },
                { 1118, "ロック中か" },
                { 1119, "攻撃方向取得" },
                { 1120, "部位グループ取得" },
                { 1121, "ノックバック距離取得" },
                { 2000, "移動キャンセル可能か" },
                { 2002, "特殊移動タイプ取得" },
                { 2003, "TAE汎用フラグ取得" },
                { 2004, "振りが当たっているか" },
                { 2005, "儀式状態を取得" },
                { 2006, "連続ガード回数を取得" },
                { 2007, "最小よろけ値を取得" },
                { 2008, "蓄積よろけ値を取得" },
                { 2009, "最大よろけ値を取得" },
                { 2010, "最大スタミナ取得" },
                { 2011, "MSB汎用パラメータ取得" },
                { 2012, "壁に当たっているか" },
                { 2013, "安全方向取得" },
                { 2014, "儀式中か" },
                { 2015, "死体運びキーフレーム化するか" },
                { 2016, "MP取得" },
                { 2017, "儀式完了か" },
                { 2018, "儀式中断か" },
            },
        };

        string filePath = "";
        public static ESD currentESD = null;
        StateGroupHandler currentSGH => (StateGroupHandler)StateGroupBox.SelectedItem ?? null;
        Dictionary<long, ESD.State> currentStateGroup => currentSGH == null ? null : currentSGH.Group;

        StateHandler currentSH => (StateHandler)StateBox.SelectedItem ?? null;
        ESD.State currentState => currentSH == null ? null : currentSH.State;

        ESD.Condition currentCondition
        {
            get
            {
                if (ConditionTree.SelectedNode == null) return null;
                return ConditionsFromNode(ConditionTree.SelectedNode).Condition;
            }
        }
        Dictionary<string, TextStyle> textStyles = new Dictionary<string, TextStyle>();
        bool loaded = false;
        System.Timers.Timer saveLabelTimer = new System.Timers.Timer();

        public GUI()
        {
            InitializeComponent();
            SetTextBoxOptions();
            OnResize();
            loaded = true;

            void hide(Object source, ElapsedEventArgs e)
            {
                if (saveLabel.InvokeRequired)
                {
                    saveLabel.Invoke(new Action(() => saveLabel.Visible = false));
                }
                else
                {
                    saveLabel.Visible = false;
                }

            }
            saveLabelTimer.Interval = 5000;
            saveLabelTimer.Elapsed += hide;
            saveLabelTimer.AutoReset = false;
        }

        public class StateGroupHandler
        {
            public long ID;
            public Dictionary<long, ESD.State> Group => currentESD.StateGroups[ID];
            public string Name
            {
                get => currentESD.StateGroupNames[ID];
                set => currentESD.StateGroupNames[ID] = value;
            }
            public string DisplayName => ID + ": " + Name;

            public StateGroupHandler(long id) => ID = id;
            public override string ToString() => Name;
        }

        public class StateHandler
        {
            public ESD.State State;
            public long ID => State.ID;
            public string DisplayName => State.ID + ": " + State.Name;

            public StateHandler(ESD.State state) => State = state;
        }

        private void openESDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ActiveForm.UseWaitCursor = true;
                    currentESD = ESD.ReadWithMetadata(ofd.FileName, false, false, ScriptingContext);
                    ActiveForm.Text = "Zeditor - " + Path.GetFileName(ofd.FileName);
                    RefreshStateGroupBox();
                    filePath = ofd.FileName;
                    ActiveForm.UseWaitCursor = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: Invalid ESD file." + Environment.NewLine + "---------" + Environment.NewLine + ex.ToString());
                    openESDToolStripMenuItem_Click(sender, e);
                    ActiveForm.UseWaitCursor = false;
                }
            }
        }

        private void StateGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearEditors();
            if (currentStateGroup != null)
            {
                RefreshStateBox();
            }
            else
            {
                StateBox.DisplayMember = "DisplayName";
                StateBox.DataSource = null;
            }
            UpdateTitleBox();
        }

        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConditionTree.Nodes.Clear();
            if (currentState == null) return;
            foreach (var condition in currentState.Conditions)
            {
                AddConditionNode(condition);
            }

            if (ConditionTree.Nodes.Count > 0) ConditionTree.SelectedNode = ConditionTree.Nodes[0];
            EntryCmdBox.Text = currentState.EntryScript;
            ExitCmdBox.Text = currentState.ExitScript;
            WhileCmdBox.Text = currentState.WhileScript;
            AfterSelect();
            UpdateTitleBox();
        }

        private string ConditionDisplay(ESD.Condition condition)
        {
            if (condition == null) return null;
            if (Regex.IsMatch(condition.Name, @"^Condition\[[A-Za-z0-9]+\]$"))
            {
                string conditionDisplay = condition.Name.Substring(10).TrimEnd(new char[] { '[', ']' });
                conditionDisplay = Regex.Replace(conditionDisplay ?? "", "^[0]+", "");
                return conditionDisplay;
            }
            else
            {
                return condition.Name;

            }
        }

        private void AddConditionNode(ESD.Condition condition)
        {
            int cNum = currentState.Conditions.IndexOf(condition);
            TreeNode cNode = new TreeNode();
            cNode.Name = cNum.ToString();
            cNode.Text = ConditionDisplay(condition);
            if (condition.TargetState != null) cNode.Text += " → " + condition.TargetState.ToString();
            ConditionTree.Nodes.Add(cNode);
            foreach (var subcondition in condition.Subconditions)
            {
                AddConditionNode(subcondition, cNode);
            }
            ConditionTree.SelectedNode = null;
        }

        private void AddConditionNode(ESD.Condition condition, TreeNode parent)
        {
            string cName = parent.Name + "-" + parent.Nodes.Count;
            TreeNode cNode = new TreeNode(cName);
            cNode.Name = cName;
            cNode.Text = ConditionDisplay(condition);
            if (condition.TargetState != null) cNode.Text += " → " + condition.TargetState.ToString();
            cNode.Name = cName;
            parent.Nodes.Add(cNode);
            foreach (var subcondition in condition.Subconditions)
            {
                AddConditionNode(subcondition, cNode);
            }
        }


        private void WriteCommands(string plainText, ref List<ESD.CommandCall> target)
        {
            string current = "";
            try
            {
                current = "EntryScript";
                currentState.EntryScript = EntryCmdBox.Text.Trim();
                current = "ExitScript";
                currentState.ExitScript = ExitCmdBox.Text.Trim();
                current = "WhileScript";
                currentState.WhileScript = WhileCmdBox.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing " + current + "\n\n" + ex.ToString());

            }
        }

        private void ConditionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AfterSelect();
            UpdateTitleBox();
        }

        private void UpdateTitleBox()
        {
            if (currentState == null)
            {
                EditorTitleBox.Text = "";
                return;
            }

            EditorTitleBox.Text = currentSGH.Name + " : " + currentState.Name + " : ";
            if (editorControl.SelectedTab == stateTab) EditorTitleBox.Text += "Commands";
            else if (editorControl.SelectedTab == conditionTab) 
            {
                if (currentCondition == null) EditorTitleBox.Text = "";
                else EditorTitleBox.Text += ConditionDisplay(currentCondition);
            }
        }

        private void SelectNode(string path)
        {
            var nodePath = path.Split('-').Select(i => Int32.Parse(i)).ToList();
            TreeNode node = ConditionTree.Nodes[nodePath[0]];
            for (int i = 1; i < nodePath.Count; i++)
            {
                node = node.Nodes[nodePath[i]];
            }
            ConditionTree.SelectedNode = node;
        }

        private void AfterSelect()
        {
            if (ConditionTree.SelectedNode == null)
            {
                EvaluatorBox.Text = "";
                PassCmdBox.Text = "";
                TargetStateNameBox.Text = "";
                TargetStateBox.Text = "";
            }
            else
            {
                var t = currentCondition.TargetState;
                if (t == null)
                {
                    TargetStateBox.Text = "";
                    TargetStateNameBox.Text = "";
                } else
                {
                    TargetStateBox.Text = t.ToString();
                    TargetStateNameBox.Text = currentStateGroup[(long)t].Name;
                }
                EvaluatorBox.Text = currentCondition.Evaluator;
                PassCmdBox.Text = currentCondition.PassScript;
            }
            UpdateTitleBox();
        }

        private void NotYet()
        {
            MessageBox.Show("Feature not yet implemented.");
        }

        private void AddConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            var cnd = new ESD.Condition();
            cnd.Evaluator = "";
            cnd.TargetState = 0;
            currentState.Conditions.Add(cnd);
            StateBox_SelectedIndexChanged(sender, e);
            ConditionTree.SelectedNode = ConditionTree.Nodes[ConditionTree.Nodes.Count - 1];
        }

        private void AddSubconditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            var path = ConditionTree.SelectedNode.Name;
            var state = currentCondition.TargetState;
            currentCondition.TargetState = null;

            var cnd = new ESD.Condition();
            cnd.Evaluator = "";
            cnd.TargetState = state ?? (long)0;
            currentCondition.Subconditions.Add(cnd);
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.LastNode;
        }

        private void DeleteConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            var name = ConditionTree.SelectedNode.Text;
            if (DialogResult.OK == MessageBox.Show("Really delete " + name + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                ConditionsFromNode(ConditionTree.SelectedNode).ParentCollection.Remove(currentCondition);
                StateBox_SelectedIndexChanged(sender, e);
                ConditionTree.Focus();  
            }
        }

        private void GoTargetBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition != null && currentCondition.TargetState != null)
            {
                int index = currentStateGroup.Keys.ToList().IndexOf((long) currentCondition.TargetState);
                StateBox.SelectedIndex = index;
            }
        }

        private ConditionHandler ConditionsFromNode(TreeNode node)
        {
            var nodePath = node.Name.Split('-').Select(i => Int32.Parse(i)).ToList();
            if (node.Parent == null) return new ConditionHandler(currentState.Conditions[nodePath[0]], currentState.Conditions);

            ESD.Condition parent = null;
            ESD.Condition cnd = currentState.Conditions[nodePath.First()];
            foreach (var n in nodePath.Skip(1))
            {
                parent = cnd;
                cnd = parent.Subconditions[n];
            }
            return new ConditionHandler(cnd, parent.Subconditions);
        }

        private void RenameAllNodes(TreeNode parentNode = null)
        {
            TreeNodeCollection nodes = parentNode == null ? ConditionTree.Nodes : parentNode.Nodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Name = parentNode == null ? i + "" : parentNode.Name + "-" + i;
                nodes[i].Text = "CND " + nodes[i].Name;
                var cnds = ConditionsFromNode(nodes[i]);
                if (cnds.Condition.TargetState != null)
                {
                    nodes[i].Text = "CND " + nodes[i].Name + " → " + cnds.Condition.TargetState;
                }
                else
                {
                    RenameAllNodes(nodes[i]);
                }
            }
        }

        private void MoveCndUpBtn_Click(object sender, EventArgs e)
        {
            ConditionTree.Focus();
            var currentNode = ConditionTree.SelectedNode;
            if (currentNode == null) return;
            TreeNodeCollection parentNodes = currentNode.Parent == null ? ConditionTree.Nodes : currentNode.Parent.Nodes;
            int index = parentNodes.IndexOf(ConditionTree.SelectedNode);
            if (index == 0) return;

            var h = ConditionsFromNode(ConditionTree.SelectedNode);
            var p = h.ParentCollection;
            var c = h.Condition;
            var i = h.Index;

            p.RemoveAt(i);
            p.Insert(i - 1, c);

            var path = ConditionTree.SelectedNode.Name;
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.PrevNode;
            ConditionTree.Focus();


        }

        private void MoveCndDownBtn_Click(object sender, EventArgs e)
        {
            ConditionTree.Focus();
            var currentNode = ConditionTree.SelectedNode;
            if (currentNode == null) return;
            TreeNodeCollection parentNodes = currentNode.Parent == null ? ConditionTree.Nodes : currentNode.Parent.Nodes;
            int index = parentNodes.IndexOf(ConditionTree.SelectedNode);
            if (index == parentNodes.Count - 1) return;

            var h = ConditionsFromNode(ConditionTree.SelectedNode);
            var p = h.ParentCollection;
            var c = h.Condition;
            var i = h.Index;

            p.RemoveAt(i);
            p.Insert(i + 1, c);

            var path = ConditionTree.SelectedNode.Name;
            StateBox_SelectedIndexChanged(sender, e);
            SelectNode(path);
            ConditionTree.SelectedNode = ConditionTree.SelectedNode.NextNode;
        }

        private void exportESDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Title = "Export ESD";
            sfd.InitialDirectory = Path.GetDirectoryName(filePath);
            sfd.FileName = Path.GetFileName(filePath);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ActiveForm.UseWaitCursor = true;
                currentESD.WriteWithMetadata(sfd.FileName, false, ScriptingContext);
                filePath = sfd.FileName;
                Form.ActiveForm.Text = "Zeditor - " + Path.GetFileName(sfd.FileName);
                ActiveForm.UseWaitCursor = false;

            }
        }

        private void TargetStateBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTargetState();
            }
        }

        private void TargetStateBox_Leave(object sender, EventArgs e)
        {
            UpdateTargetState();
        }

        private void UpdateTargetState()
        {
            var cnd = currentCondition;
            if (cnd != null)
            {
                string s = TargetStateBox.Text.Trim();
                int newValue;
                bool success = int.TryParse(s, out newValue);
                if (s == "" && cnd.Subconditions.Count == 0)
                {
                    cnd.TargetState = null;
                    ConditionTree.SelectedNode.Text = ConditionDisplay(cnd);
                    TargetStateBox.Text = "";
                }
                else if (!success)
                {
                    MessageBox.Show("Invalid target state.");
                    TargetStateBox.Text = cnd.TargetState.ToString();
                }
                else if (cnd.Subconditions.Count > 0)
                {
                    MessageBox.Show("Conditions with subconditions can't have target states.");
                    TargetStateBox.Text = cnd.TargetState.ToString();
                }
                else
                {
                    currentCondition.TargetState = (long)newValue;
                    ConditionTree.SelectedNode.Text = ConditionDisplay(cnd);
                    TargetStateNameBox.Text = currentStateGroup[(long)newValue].Name;
                }
            }
        }

        private void SetTextBoxOptions()
        {
            FastColoredTextBox[] boxes = { PassCmdBox, EntryCmdBox, ExitCmdBox, WhileCmdBox, EvaluatorBox };
            foreach (var box in boxes)
            {
                box.ChangeFontSize(3);
                box.AllowSeveralTextStyleDrawing = true;
                box.WordWrap = true;
            }

            textStyles["separator"] = new TextStyle(Brushes.Red, Brushes.White, FontStyle.Regular);
            textStyles["command"] = new TextStyle(Brushes.Blue, Brushes.White, FontStyle.Regular);
            textStyles["num"] = new TextStyle(Brushes.DarkMagenta, Brushes.White, FontStyle.Bold);
            textStyles["regular"] = new TextStyle(Brushes.Black, Brushes.White, FontStyle.Bold);
            textStyles["comment"] = new TextStyle(Brushes.DarkGreen, Brushes.White, FontStyle.Regular);
        }

        private void BoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!loaded) return;
            e.ChangedRange.ClearStyle(textStyles.Values.ToArray());
            e.ChangedRange.SetStyle(textStyles["separator"], "[$]");
            e.ChangedRange.SetStyle(textStyles["command"], @"[A-Za-z_]+[(]");
            e.ChangedRange.SetStyle(textStyles["num"], @"[0-9]");
            e.ChangedRange.SetStyle(textStyles["regular"], "[():;]");
            e.ChangedRange.SetStyle(textStyles["comment"], @"[/]{2}.*(\n|$)");

        }

        private void UpdateTitleBox(object sender, EventArgs e)
        {
            UpdateTitleBox();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveEdit();
        }

        private void SaveEdit(object sender = null, EventArgs e = null)
        {
            if (currentState == null) return;
            else if (editorControl.SelectedTab == stateTab)
            {
                currentState.EntryScript = EntryCmdBox.Text;
                currentState.ExitScript = ExitCmdBox.Text;
                currentState.WhileScript = WhileCmdBox.Text;
            }
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) return;
                currentCondition.PassScript = PassCmdBox.Text;
                currentCondition.Evaluator = EvaluatorBox.Text;
            }
        }

        private void ShowSuccessLabel()
        {

            saveLabel.Visible = true;
            saveLabelTimer.Stop();
            saveLabelTimer.Start();
        }

        private void RevertBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            else if (editorControl.SelectedTab == stateTab)
            {
                EntryCmdBox.Text = currentState.EntryScript;
                ExitCmdBox.Text = currentState.ExitScript;
                WhileCmdBox.Text = currentState.WhileScript;
            }
            else if (editorControl.SelectedTab == conditionTab)
            {
                if (currentCondition == null) return;
                PassCmdBox.Text = currentCondition.PassScript;
                EvaluatorBox.Text = currentCondition.Evaluator;
            }
        }

        private void saveEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveEdit();
        }

        private void cloneStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            var newState = CloneState(currentState);
            currentStateGroup[newState.ID] = newState;
            RefreshStateBox(newState.ID);
        }

        private ESD.State CloneState(ESD.State source, long? groupID = null)
        {
            var newState = new ESD.State();

            void CloneCondition(ESD.Condition srcCondition, ESD.Condition parentCondition = null)
            {
                var newCondition = new ESD.Condition();
                newCondition.Name = srcCondition.Name;
                newCondition.TargetState = srcCondition.TargetState;
                newCondition.Evaluator = srcCondition.Evaluator;
                foreach (var sub in srcCondition.Subconditions) CloneCondition(sub, newCondition);
                newCondition.PassScript = srcCondition.PassScript;
                if (parentCondition == null) newState.Conditions.Add(newCondition);
                else parentCondition.Subconditions.Add(newCondition);
            }

            foreach (var condition in source.Conditions) CloneCondition(condition);
            newState.EntryScript = source.EntryScript;
            newState.ExitScript = source.ExitScript;
            newState.WhileScript = source.WhileScript;


            if (groupID == null || groupID == currentSGH.ID) newState.ID = currentStateGroup.Max(p => p.Key) + 1;
            else newState.ID = source.ID;

            if (Regex.IsMatch(source.Name, @"^State\d+\-\d+$")) newState.Name = "State" + groupID + "-" + newState.ID;
            else newState.Name = source.Name;

            return newState;
        }

        private void addNewStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long stateId = currentStateGroup.Keys.Max() + 1;
            var state = new ESD.State();
            state.ID = stateId;
            state.Name = "State" + currentSGH.ID + "-" + stateId;
            currentStateGroup[stateId] = state;
            StateGroupBox_SelectedIndexChanged(sender, e);
            SelectState(stateId);
        }

        private void deleteStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            long stateId = currentSH.ID;
            if (DialogResult.OK == MessageBox.Show("Really delete state " + stateId + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                int i = StateBox.SelectedIndex - 1;
                currentStateGroup.Remove(stateId);
                StateGroupBox_SelectedIndexChanged(sender, e);
                if (i > -1 && i < StateBox.Items.Count) StateBox.SelectedIndex = i;
                else ClearEditors();
            }
        }

        private void saveEditorContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveEdit();
        }

        private void noHelpForYouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("created by AinTunez");
        }

        private void AddGroupBtn_Click(object sender, EventArgs e)
        {
            var k = GetNewKey();
            if (!k.HasValue) return;
            if (currentESD.StateGroups.Keys.Contains(k.Value))
            {
                MessageBox.Show("ERROR: Key already exists.");
                AddGroupBtn_Click(sender, e);
                return;
            }
            currentESD.StateGroups[k.Value] = new Dictionary<long, ESD.State>();
            currentESD.StateGroupNames[k.Value] = "StateGroup" + k.Value;
            ClearEditors();
            RefreshStateGroupBox(k.Value);
        }

        private void CloneGroupBtn_Click(object sender, EventArgs e)
        {
            if (currentStateGroup == null) return;
            var k = GetNewKey();
            if (!k.HasValue) return;
            if (currentESD.StateGroups.Keys.Contains(k.Value))
            {
                MessageBox.Show("ERROR: Key already exists.");
                CloneGroupBtn_Click(sender, e);
                return;
            }
            var newGroup = new Dictionary<long, ESD.State>();
            foreach (var pair in currentStateGroup)
            {
                newGroup[pair.Key] = CloneState(currentStateGroup[pair.Key], k.Value);
            }
            currentESD.StateGroups[k.Value] = newGroup;
            currentESD.StateGroupNames[k.Value] = "StateGroup" + k.Value;
            ClearEditors();
            RefreshStateGroupBox(k.Value);
        }

        private void DeleteGroupBtn_Click(object sender, EventArgs e)
        {
            if (currentStateGroup == null) return;
            var key = (long)StateGroupBox.SelectedItem;
            if (DialogResult.OK == MessageBox.Show("Really delete group " + key + "?", "Confirm", MessageBoxButtons.OKCancel))
            {
                currentESD.StateGroups.Remove(key);
                ClearEditors();
                RefreshStateGroupBox();
            }
        }

        private void ClearEditors()
        {
            ConditionTree.Nodes.Clear();
            EditorTitleBox.Text = "";
            PassCmdBox.Text = "";
            WhileCmdBox.Text = "";
            EntryCmdBox.Text = "";
            ExitCmdBox.Text = "";
            EvaluatorBox.Text = "";
            TargetStateBox.Text = "";
        }

        public long? GetNewKey()
        {
            string key = "";
            var box = InputBox("Key", "Enter new key for state group:", ref key);
            if (box == DialogResult.OK)
            {
                long val;
                bool success = long.TryParse(key.Trim(), out val);
                if (success) return val;
                else
                {
                    MessageBox.Show("Invalid key.");
                    GetNewKey();
                }
            }
            return null;
        }

        public DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.SelectAll();

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void editESDPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentESD == null) return;
            var editor = new PropertyEditor(currentESD);
            int x = DesktopBounds.Left + (Width - editor.Width) / 2;
            int y = DesktopBounds.Top + (Height - editor.Height) / 2;
            editor.Location = new Point(x, y);
            editor.StartPosition = FormStartPosition.Manual;
            editor.ShowDialog();
        }

        private void OnResize()
        {
            int h = flowLayoutPanel1.Height / 3 - 3;
            int w = flowLayoutPanel1.Width - 10;
            groupBox5.Height = h;
            groupBox6.Height = h;
            groupBox7.Height = h;
            groupBox5.Width = w;
            groupBox6.Width = w;
            groupBox7.Width = w;

            int h2 = flowLayoutPanel3.Height / 2 - 3;
            int w2 = flowLayoutPanel3.Width - 10;
            groupBox3.Height = h2;
            groupBox4.Height = h2;
            groupBox3.Width = w2;
            groupBox4.Width = w2;


        }

        private void GUI_Resize(object sender, EventArgs e)
        {
            OnResize();
        }

        private void RenameStateBtn_Click(object sender, EventArgs e)
        {
            if (currentState == null) return;
            int index = StateBox.SelectedIndex;
            string name = currentState.Name;
            var box = InputBox("Rename State", "Enter a new name for the state: ", ref name);
            if (box == DialogResult.OK)
            {
                string newName = "";
                if (string.IsNullOrWhiteSpace(name))
                {
                    newName = "State" + (long)StateGroupBox.SelectedItem + "-" + currentState.ID;
                }
                else
                {
                    newName = name.Trim();
                }
                currentState.Name = newName;
                RefreshStateBox();
                StateBox.SelectedIndex = index;
            }
        }

        private void RefreshStateBox(long? key = null)
        {
            StateBox.DataSource = null;
            if (currentStateGroup == null) return;
            StateBox.DisplayMember = "DisplayName";
            StateBox.DataSource = currentStateGroup.Values.Select(s => new StateHandler(s)).ToList();
            if (key.HasValue) SelectState(key.Value);
           
        }

        private void SelectState(long key)
        {
            foreach (var item in StateBox.Items)
            {
                var h = (StateHandler)item;
                if (h.ID == key)
                {
                    StateBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void SelectGroup(long key)
        {
            foreach (var item in StateGroupBox.Items)
            {
                var h = (StateGroupHandler)item;
                if (h.ID == key)
                {
                    StateGroupBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void RenameConditionBtn_Click(object sender, EventArgs e)
        {
            if (currentCondition == null) return;
            string name = currentCondition.Name;
            var box = InputBox("Rename State", "Enter a new name for " + currentCondition.Name + ":", ref name);
            if (box == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Invalid condition name.");
                    RenameConditionBtn_Click(sender, e);
                }
                else
                {
                    var path = ConditionTree.SelectedNode.Name;
                    currentCondition.Name = name.Trim();
                    StateBox_SelectedIndexChanged(sender, e);
                    SelectNode(path);
                }
            }
        }


        public class ConditionHandler
        {
            public ESD.Condition Condition;
            public List<ESD.Condition> ParentCollection;
            public int Index => ParentCollection.IndexOf(Condition);

            public ConditionHandler(ESD.Condition cnd, List<ESD.Condition> collection)
            {
                Condition = cnd;
                ParentCollection = collection;
            }
        }
        public enum EditType
        {
            Command, Condition, Null
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveESDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (currentESD == null) return;
            SaveEdit(sender, e);
            ActiveForm.UseWaitCursor = true;
            try
            {
                currentESD.WriteWithMetadata(filePath, false, ScriptingContext);
                ShowSuccessLabel();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ActiveForm.UseWaitCursor = false;
        }

        private void RenameGroupBtn_Click(object sender, EventArgs e)
        {
            if (currentStateGroup == null) return;
            var handler = currentSGH;
            string name = currentSGH.Name;
            var box = InputBox("Rename State", "Enter a new name for " + handler.Name + ":", ref name);
            if (box == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    handler.Name = "StateGroup" + handler.ID;
                }
                else
                {
                    handler.Name = name.Trim();
                    RefreshStateGroupBox();
                }
            }
        }

        private void RefreshStateGroupBox(long? key = null)
        {
            StateGroupBox.DataSource = null;
            if (currentESD == null) return;
            StateGroupBox.DisplayMember = "DisplayName";
            StateGroupBox.DataSource = currentESD.StateGroups.Select(kv => new StateGroupHandler(kv.Key)).ToList();
            if (key.HasValue) SelectGroup(key.Value);

        }

        private void editorControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTitleBox();
            OnResize();
        }
    }
}
