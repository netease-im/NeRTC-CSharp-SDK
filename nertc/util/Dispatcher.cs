#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_IOS || UNITY_ANDROID
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;


namespace nertc 
{ 
	/// 工具类，方便在非UI线程更新UI
	/// </summary>
	public class Dispatcher : MonoBehaviour
	{
		public static int maxThreads = 8;
		static Dispatcher _current;
		static bool initialized;
		static int numThreads;
		List<Action> _actions = new List<Action>();
		List<Action> _currentActions = new List<Action>();
		List<DelayedQueueItem> _currentDelayed = new List<DelayedQueueItem>();
		List<DelayedQueueItem> _delayed = new List<DelayedQueueItem>();

        public event Action OnUpdate;
        public event Action OnLateUpdate;
        public static Dispatcher Current
		{
			get
			{
				Initialize();
				return _current;
			}
		}
		public static void QueueOnMainThread(Action action)
		{
			QueueOnMainThread(action, 0f);
		}
		public static void QueueOnMainThread(Action action, float time)
		{
            var current = Current;
            if(current == null)
            {
                return;
            }
			if (!Mathf.Approximately(time, 0))
			{
				lock (current._delayed)
				{
                    current._delayed.Add(new DelayedQueueItem { time = Time.time + time, action = action });
				}
			}
			else
			{
				lock (current._actions)
				{
                    current._actions.Add(action);
				}
			}
		}
		public static Thread RunAsync(Action a)
		{
			Initialize();
			while (numThreads >= maxThreads)
			{
				Thread.Sleep(1);
			}
			Interlocked.Increment(ref numThreads);
			ThreadPool.QueueUserWorkItem(RunAction, a);
			return null;
		}
		static void Initialize()
		{
			if (!initialized)
			{
				if (!Application.isPlaying)
					return;
				initialized = true;
				var g = new GameObject("Dispatcher");
                DontDestroyOnLoad(g);
                _current = g.AddComponent<Dispatcher>();
			}
		}
		static void RunAction(object action)
		{
			try
			{
				((Action)action)();
			}
			finally
			{
				Interlocked.Decrement(ref numThreads);
			}
		}
		void Awake()
		{
			_current = this;
			initialized = true;
		}
		void OnDisable()
		{
			if (_current == this)
			{
				_current = null;
			}
		}
		void Update()
		{
            OnUpdate?.Invoke();

            lock (_actions)
            {
                _currentActions.Clear();
                _currentActions.AddRange(_actions);
                _actions.Clear();
            }
            foreach (var a in _currentActions)
            {
                a();
            }
            lock (_delayed)
            {
                _currentDelayed.Clear();
                float curtime = Time.time;
                int count = _delayed.Count;
                for (int i = 0; i < count; i++)
                {
                    if (_delayed[i].time <= curtime)
                        _currentDelayed.Add(_delayed[i]);
                }

                foreach (var item in _currentDelayed)
                    _delayed.Remove(item);
            }
            foreach (var delayed in _currentDelayed)
            {
                delayed.action();
            }
        }
        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }

        public struct DelayedQueueItem
		{
			public Action action;
			public float time;
		}
	}

}
#endif