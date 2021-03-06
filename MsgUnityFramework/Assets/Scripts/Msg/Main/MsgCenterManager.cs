﻿/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题:消息处理中心
 *
 *		功能：负责消息的转发
 *
 *		日期 2018.6.22
*/

using System;

namespace Msg
{
    public class MsgCenterManager
    {
        #region 单例
        private static MsgCenterManager _instance;
        private static readonly object _lockobj;
        static MsgCenterManager()
        {
            _lockobj = new object();
        }

        private MsgCenterManager()
        {
        }

        public static MsgCenterManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                            _instance = new MsgCenterManager();
                    }
                }
                return _instance;
            }
        }
        #endregion


        /// <summary>
        /// 发送消息
        ///     处理项目中所有的发送消息
        /// </summary>
        /// <param name="areaCode">消息的区域码</param>
        /// <param name="eventCode">消息的事件码</param>
        /// <param name="msgValue">消息的参数</param>
        public void Dispatch(int areaCode, int eventCode, object msgValue)
        {
            switch (areaCode)
            {
                case AreaCode.AUDIO:
                    MsgAudioManager.Instance.Execute(eventCode, msgValue);
                    break;
                case AreaCode.CHARACTER:
                    MsgCharacterManager.Instance.Execute(eventCode, msgValue);
                    break;
                case AreaCode.GAME:
                    MsgGameManager.Instance.Execute(eventCode, msgValue);
                    break;
                case AreaCode.NET:
                    MsgNetManager.Instance.Execute(eventCode, msgValue);
                    break;
                case AreaCode.UI:
                    MsgUIManager.Instance.Execute(eventCode, msgValue);
                    break;
                case AreaCode.VIDEO:
                    MsgVideoManager.Instance.Execute(eventCode, msgValue);
                    break;
                // 添加新的模块 
                default:
                    throw new Exception("需要的Manager在这里没添加");
            }
        }
    }
}


