using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    public class MissionSelector : MonoBehaviour
    {
        #region Inspector
        [SerializeField] protected MissionList_script _missionList;
        #endregion

        #region Protected
        protected int _currentIndex = 0;
        #endregion

        #region Properties
        public int CurrentIndex => _currentIndex;
        #endregion



        public void Clamp_Index()
        {
            if (_missionList.Total_Missions == 0)
            {
                Debug.Log("Error'umsu");
            }


            if (_currentIndex >= _missionList.Total_Missions)
            {
                _currentIndex = 0;
            }

            if (_currentIndex < 0)
            {
                _currentIndex = _missionList.Total_Missions - 1;
            }
        }







        public void Set_Index(int index_ms)
        {
            _currentIndex = index_ms;
            Clamp_Index();
        }

        public void Increment_Index()
        {
            Set_Index(_currentIndex + 1);
        }

        public void Decrement_Index()
        {
            Set_Index(_currentIndex - 1);
        }
        





        public MissionSpecs Get_Mission(int index_g)
        {
            return _missionList.GetMission(index_g);
        }
        public MissionSpecs Get_Current_Mission()
        {
            return _missionList.GetMission(_currentIndex);
        }


    } 
}
