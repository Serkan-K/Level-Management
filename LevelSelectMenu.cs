using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LevelManagement.Missions;

namespace LevelManagement
{
    [RequireComponent(typeof(MissionSelector))]
    public class LevelSelectMenu : Menu<LevelSelectMenu>
    {
        #region Inspector
        [SerializeField] protected TMP_Text _nameText;
        [SerializeField] protected TMP_Text _descriptionText;
        [SerializeField] protected Image _previewImage;

        [SerializeField] protected float _playDelay = 0.5f;
        [SerializeField] protected TransitionFader _play_TransitonPrefab;
        #endregion

        #region Protected
        protected MissionSelector _missionSelector;
        protected MissionSpecs _currentMission;
        #endregion


        protected override void Awake()
        {
            base.Awake();
            _missionSelector = GetComponent<MissionSelector>();
            Update_Info();
        }

        private void OnEnable()
        {
            Update_Info();
        }







        public void Update_Info()
        {
            _currentMission = _missionSelector.Get_Current_Mission();

            _nameText.text = _currentMission?.Name;
            _descriptionText.text = _currentMission?.Description;
            _previewImage.sprite = _currentMission?.Image;
            _previewImage.color = Color.white;
        }









        public void On_Next_Pressed()
        {
            _missionSelector.Increment_Index();
            Update_Info();
        }

        public void On_Previous_Pressed()
        {
            _missionSelector.Decrement_Index();
            Update_Info();
        }

        public void On_Play_pressed()
        {
            StartCoroutine(PlayMission_routine(_currentMission.SceneName));
        }


        private IEnumerator PlayMission_routine(string sceneName_ls)
        {
            TransitionFader.Play_transition(_play_TransitonPrefab);
            LevelLoader.LoadLevel(sceneName_ls);
            yield return new WaitForSeconds(_playDelay);
            Game_inMenu.Open_T();

        }


    }
}
