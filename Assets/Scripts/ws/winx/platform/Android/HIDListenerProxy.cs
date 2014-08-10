﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ws.winx.platform.android
{
    public class HIDListenerProxy : AndroidJavaProxy/* count this as Interface so you need to implement */
	{
        public event EventHandler DeviceConnectedEvent;
        public event EventHandler DeviceDisconnectedEvent;
        public event EventHandler Error;

        public HIDListenerProxy() : base("ws.winx.hid.IHIDListener") { }
        void onAttached(AndroidJavaClass device) { if(DeviceConnectedEvent!=null) DeviceConnectedEvent(this,);}
        void onDetached(int pid) { if(DeviceDisconnectedEvent!=null) DeviceDisconnectedEvent(this,);}
        void onError(String error) { if(Error!=null) Error(this,);}
	}
}
