﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Threading;

namespace ws.winx.input
{
    public class InputEvent
    {



        protected int _stateNameHash;
        protected static GameObject _container;
        //public static delegate bool GetInputDelegate(int stateNameHash,bool atOnce);
		protected static Func<int,bool,bool> _action;

        protected enum EventType:uint
        {
            CONT=0,
            UP,
            DOWN
        }


        public InputEvent(int stateNameHash)
        {
            _stateNameHash = stateNameHash;
        }

        public InputEvent(string stateName)
        {
            _stateNameHash = Animator.StringToHash(stateName);
        }


        protected void CreateGameObjectLooper()
        {
            if (_container == null)
            {
                _container = new GameObject("InputEventManagerBehaviour");

                InputEventManagerBehaviour w = _container.AddComponent<InputEventManagerBehaviour>();
                w.Events = InputEvent.Events;
            }
        }



        private static Dictionary<int, Delegate[]> __events;
        protected static Dictionary<int, Delegate[]> Events
        {
            get
            {
                if (__events == null)
                    __events = new Dictionary<int, Delegate[]>();
                return __events;
            }

        }


        public event EventHandler<EventArgs> UP
        {
            add
            {
                AddHandler(_stateNameHash, value,(uint)EventType.UP);

            }
            remove
            {
                RemoveHandler(_stateNameHash, value,(uint)EventType.UP);
            }
        }



        public event EventHandler<EventArgs> DOWN
        {
            add
            {
                AddHandler(_stateNameHash, value,(uint)EventType.DOWN);

              
            }
            remove
            {
                RemoveHandler(_stateNameHash, value,(uint)EventType.DOWN);
            }
        }



        public event EventHandler<EventArgs>  CONT 
        {
            add            {
                AddHandler(_stateNameHash, value, (uint)EventType.CONT);
            }
            remove
            {
                RemoveHandler(_stateNameHash, value,(uint)EventType.CONT);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="inx">0-Continuios events,1-Up,2-Down events</param>
        protected void AddHandler(int key, Delegate value,uint inx)
        {

            Delegate[] d;


            if (Events.TryGetValue(key, out d))
            {
                if (d[inx] != null)
                    d[inx] = Delegate.Combine(d[inx], value);
                else
                    Events[key][inx] = value;
            }
            else
            {
                Events[key]=new Delegate[3];
                Events[key][inx] = value;

            }
        }


        protected void RemoveHandler(int key, Delegate value,uint inx)
        {
            Delegate[] d;

            if (Events.TryGetValue(key, out d))
            {
                Events[key][inx] = Delegate.Remove(d[inx], value);
            }
            // else... no error for removal of non-existant delegate
            //
        }




        public void Dispose()
        {
            if(_container)
            UnityEngine.Object.Destroy(_container);

            _container = null;

            if (InputEvent.Events != null)
            {

                InputEvent.Events.Remove(_stateNameHash);
           
            }

            
        }



      
    }
}
