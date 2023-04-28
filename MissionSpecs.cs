using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    [Serializable]
    public class MissionSpecs
    {
        #region Inspector
        [SerializeField] protected string _name;
        [SerializeField] [Multiline] protected string _description;
        [SerializeField] protected string _sceneName;
        [SerializeField] protected string _id;
        [SerializeField] protected Sprite _image;
        #endregion

        #region Properties
        public string Name => _name;
        public string Description => _description;
        public string SceneName => _sceneName;
        public string Id => _id;
        public Sprite Image => _image;
        #endregion

    }
}
