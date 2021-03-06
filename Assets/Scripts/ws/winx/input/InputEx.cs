//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections.Generic;
using ws.winx.platform;
using ws.winx.devices;
using System.Linq;

namespace ws.winx.input
{


		/// <summary>
		/// Input ex arguments.
		/// </summary>
		public class InputExArgs : EventArgs
		{

				public InputAction action;

				public InputExArgs (InputAction action)
				{

						this.action = action;

				}
		}

		public class InputEx
		{


		#region ControllerDevicesCollection
		
				/// <summary>
				/// Defines a collection of ControllerAxes.
				/// </summary>
				public  sealed class DevicesCollection : IDeviceCollection
				{
			#region Fields
						readonly Dictionary<string, IDevice> IDToDevice;
						readonly Dictionary<byte, string> IndexToID;
						List<IDevice> _iterationCacheList;//
						bool _isEnumeratorDirty = true;
			
			#endregion
			
			#region Constructors
			
						internal DevicesCollection ()
						{
								IDToDevice = new Dictionary<string, IDevice> ();
				
								IndexToID = new Dictionary<byte, string> ();
				
						}
			
			#endregion
			
			#region Public Members
			
			
			
			
			#region IDeviceCollection implementation
			
			
						/// <summary>
						/// Remove the specified device with specified PID.
						/// </summary>
						/// <param name="PID">PI.</param>
						public void Remove (string ID)
						{
								IndexToID.Remove ((byte)IDToDevice [ID].Index);
								IDToDevice.Remove (ID);
				
								_isEnumeratorDirty = true;
						}
			
						/// <summary>
						/// Remove the specified device with specified index byte(0-15)
						/// </summary>
						/// <param name="index">Index.</param>
						public void Remove (byte index)
						{
								string id = IndexToID [index];
				
								//PIDToDevice[pid].
								IndexToID.Remove (index);
								IDToDevice.Remove (id);
				
								_isEnumeratorDirty = true;
						}
			
			
			
						/// <summary>
						/// Gets the <see cref="ws.winx.input.InputManager+JoystickDevicesCollection"/> at the specified index.
						/// use case (byte)#
						/// </summary>
						/// <param name="index">Index.</param>
						public IDevice this [byte index] {
								get { return IDToDevice [IndexToID [index]]; }
				
						}
			
						public IDevice GetDeviceAt (int index)
						{
								return IDToDevice [IndexToID [(byte)index]];
						}
			
			
						/// <summary>
						/// Gets or sets the <see cref="ws.winx.input.InputManager+JoystickDevicesCollection"/> with the specified PID.
						/// </summary>
						/// <param name="PID">PI.</param>
						public IDevice this [string ID] {
								get { return IDToDevice [ID]; }
								set {
										IndexToID [(byte)value.Index] = ID;
										IDToDevice [ID] = value;
					
										_isEnumeratorDirty = true;
					
								}
						}
			
						/// <summary>
						/// Containses the key of device index (0-15) Joystick0,1..15.
						/// </summary>
						/// <returns>true</returns>
						/// <c>false</c>
						/// <param name="index">Index.</param>
						public bool ContainsIndex (int index)
						{
								return IndexToID.ContainsKey ((byte)index);
						}
			
						/// <summary>
						/// Containses the key of device with PID
						/// </summary>
						/// <returns>true</returns>
						/// <c>false</c>
						/// <param name="id">id.</param>
						public bool ContainsID (string id)
						{
								return IDToDevice.ContainsKey (id);
						}
			
						public void Clear ()
						{
                           

								IndexToID.Clear ();
								IDToDevice.Clear ();

                                _isEnumeratorDirty = true;
						}
			
						public System.Collections.IEnumerator GetEnumerator ()
						{
								if (_isEnumeratorDirty || _iterationCacheList.Count!=IDToDevice.Count) {
										_iterationCacheList = IDToDevice.Values.ToList<IDevice> ();
										_isEnumeratorDirty = false;
					
					
								}
				
								return _iterationCacheList.GetEnumerator ();
				
						}
			
			
			
						/// <summary>
						/// Gets a System.Int32 indicating the available amount of JoystickDevices.
						/// </summary>
						public int Count {
								get { return IDToDevice.Count; }
						}
			
			#endregion
			
			#endregion
			
			
			
			
			
			
			
				}
		#endregion;

				static DevicesCollection _devices;
		
				internal static DevicesCollection Devices {
			
						get {  
								if (_devices == null)
										_devices = new DevicesCollection (); 
								return _devices; 
						}


			
				}

                //static InputPlayer _currentPlayer;
		
                //internal static InputPlayer currentPlayer {
                //        get {
                //                return _currentPlayer;
                //        }
                //        set {

                //                _currentPlayer = value;
					

                //        }
                //}

				private static readonly object syncRoot = new object ();
		
			//	public event EventHandler<InputExArgs> InputProcessed;

				public static int MAX_NUM_JOYSTICK_BUTTONS = 20;
				public static int MAX_NUM_MOUSE_BUTTONS = 7;


				public delegate bool KeyCodeInputResolverCallback (KeyCode code);

				static KeyCodeInputResolverCallback IGetKey = Input.GetKey;
				static KeyCodeInputResolverCallback IGetKeyUp = Input.GetKeyUp;
				static KeyCodeInputResolverCallback IGetKeyDown = Input.GetKeyDown;
				static Dictionary<int, ButtonDetails> _isKeyState = new Dictionary<int,ButtonDetails> ();
				static int _numJoystickButtons = InputEx.MAX_NUM_JOYSTICK_BUTTONS;
				static int _numMouseButtons = InputEx.MAX_NUM_MOUSE_BUTTONS;
				static int _code;
			//	static int _codeFromGUIEvent;
				static int _frameCountEditor;
				static int _frameCountEditorPrev;
			//	static int _frameCountPrev;
				static int _lastCode;

				public static int LastCode {
						get { return InputEx._lastCode; }
						internal set { InputEx._lastCode = value; }
				}
      
				//		static 		int _lastFrame=-1;
				static KeyCode _key;
				static KeyCode _button;
				static int _numJoysticks = 0;
				static KeyCode[] _keys = new KeyCode[]{
			KeyCode.Backspace,
			KeyCode.A,
			KeyCode.B,
			KeyCode.C,
			KeyCode.D,
			KeyCode.E,
			KeyCode.F,
			KeyCode.G,
			KeyCode.H,
			KeyCode.I,
			KeyCode.J,
			KeyCode.K,
			KeyCode.L,
			KeyCode.M,
			KeyCode.N,
			KeyCode.O,
			KeyCode.P,
			KeyCode.Q,
			KeyCode.R,
			KeyCode.S,
			KeyCode.T,
			KeyCode.U,
			KeyCode.V,
			KeyCode.W,
			KeyCode.X,
			KeyCode.Y,
			KeyCode.Z,
			KeyCode.UpArrow,
			KeyCode.DownArrow,
			KeyCode.RightArrow,
			KeyCode.LeftArrow,
			KeyCode.F1,
			KeyCode.F2,
			KeyCode.F3,
			KeyCode.F4,
			KeyCode.F5,
			KeyCode.F6,
			KeyCode.F7,
			KeyCode.F8,
			KeyCode.F9,
			KeyCode.F10,
			KeyCode.F11,
			KeyCode.F12,
			KeyCode.F13,
			KeyCode.F14,
			KeyCode.F15,
			KeyCode.Alpha0,
			KeyCode.Alpha1,
			KeyCode.Alpha2,
			KeyCode.Alpha3,
			KeyCode.Alpha4,
			KeyCode.Alpha5,
			KeyCode.Alpha6,
			KeyCode.Alpha7,
			KeyCode.Alpha8,
			KeyCode.Alpha9,
			KeyCode.RightShift,
			KeyCode.LeftShift,
			KeyCode.RightControl,
			KeyCode.LeftControl,
			KeyCode.RightAlt,
			KeyCode.LeftAlt,
			KeyCode.LeftCommand,
			KeyCode.LeftApple,
			KeyCode.LeftWindows,
			KeyCode.RightCommand,
			KeyCode.RightApple,
			KeyCode.RightWindows,
			KeyCode.Space
		};
				private static float _lastCodeTime;
				//private static volatile InputEx instance;





				/// <summary>
				/// Gets or sets the number joystick buttons.
				/// </summary>
				/// <value>The number joystick buttons.</value>
				public static int numJoystickButtons {
						get { return _numJoystickButtons; }
						set { _numJoystickButtons = Mathf.Min (MAX_NUM_JOYSTICK_BUTTONS, value); }
				}

				/// <summary>
				/// Gets the number joysticks.
				/// </summary>
				/// <value>The number joysticks.</value>
				public static int numJoysticks {
						get { return _numJoysticks; }

				}

				/// <summary>
				/// Gets the key.
				/// </summary>
				/// <value>The key.</value>
				public static KeyCode key {
						get { return _key; }
				}

				/// <summary>
				/// Gets the button.
				/// </summary>
				/// <value>The button.</value>
				public static KeyCode button {
						get { return _button; }
				}



				/// <summary>
				/// Gets or sets the array of KeyCode keys that could be used in the InputMapping
				/// </summary>
				/// <value>The keys.</value>
				public static KeyCode[] keys {
						get { return _keys; }
						set { _keys = value; }
				}


				/// <summary>
				/// Sets the keys from string array. Ex. string[]{"A","UpArrow","F1",...}
				/// </summary>
				/// <value>The string keys.</value>
				public static String[] stringKeys {
						set {
								if (value != null && value.Length < 1)
										return;
								int len = value.Length;
								_keys = new KeyCode[len];
								for (int i = 0; i < len; i++) {
										_keys [i] = (KeyCode)Enum.Parse (typeof(KeyCode), value [i]);
								}
						}
				}


				/// <summary>
				/// Gets the code.
				/// </summary>
				/// <value>The code.</value>
				public static int code {
						get { return _code; }

				}

				public static bool GetAnyInputDown (int id)
				{

						return Input.anyKeyDown || Devices.GetDeviceAt (id).GetAnyInputDown ();

				}

				/// <summary>
				/// Gets a value indicating whether this <see cref="ws.winx.input.InputEx"/> any key down.
				/// from any Joystick (not to be used in 2plr hot seat)
				/// </summary>
				/// <value><c>true</c> if any key down; otherwise, <c>false</c>.</value>
				public static bool anyKeyDown {
						get {
								return Input.anyKeyDown || anyKeyDownOnAny ();
						}
				}

				/// <summary>
				/// any key on any joystick device
				/// </summary>
				/// <returns></returns>
				static bool anyKeyDownOnAny ()
				{
						lock (syncRoot) {
								

								foreach (IDevice device in Devices)
										if (device.GetAnyInputDown ())
												return true;

								return false;
						}
				}

				public int numMouseButtons {
						get { return _numMouseButtons; }
						set { _numMouseButtons = Mathf.Min (MAX_NUM_MOUSE_BUTTONS, value); }
				}






      


				//!!! IMPORTANT: Input happen every frame. If there is no refresh from the hardware device 
				// Input give same values just states are refreshed from DOWN->HOLD (value=1 stay) and UP->NONE (value=0 stay)

				/// <summary>
				/// Gets the axis.
				/// </summary>
				/// <returns>The axis.</returns>
				/// <param name="action">Action.</param>
				public static float GetInputAnalog (InputAction action,IDevice device)
				{
						int code = action.getCode(device);
                       // action.getCode(_currentPlayer._Device.profile);


					
						
						lock (syncRoot) {
							
							
							if (device!=null) {
								
								
								return device.GetInputAnalog (code);
								
								
								
							} else {
								float axisValue=0f;

									foreach (IDevice dev in Devices)
										if((axisValue=dev.GetInputAnalog (code))!=0f)
										return axisValue;
										
								
									return 0f;		
					
							}
							
						}



		}
		
		
		
		
		
		
		
		/// <summary>
		/// Gets the key.
		/// </summary>
				/// <returns><c>true</c>, if key was gotten, <c>false</c> otherwise.</returns>
				/// <param name="action">Action.</param>
				internal static bool GetInputHold (InputAction action,IDevice Device)
				{
						return GetInputDigital (action, ButtonState.Hold,Device);
			
				}


	
				/// <summary>
				/// Gets the input hold.
				/// </summary>
				/// <returns><c>true</c>, if input hold was gotten, <c>false</c> otherwise.</returns>
				/// <param name="code">Code.</param>
				internal static bool GetInputHold (int code,IDevice Device)
				{
					return GetInputDigital (code, ButtonState.Hold,Device);
			
				}



				/// <summary>
				/// Gets the key up.
				/// </summary>
				/// <returns><c>true</c>, if key up was gotten, <c>false</c> otherwise.</returns>
				/// <param name="action">Action.</param>
				internal static bool GetInputUp (InputAction action,IDevice Device)
				{
					return GetInputDigital (action, ButtonState.Up,Device);
				}


				/// <summary>
				/// Gets the input down.
				/// </summary>
				/// <returns><c>true</c>, if input down was gotten, <c>false</c> otherwise.</returns>
				/// <param name="action">Action.</param>
				public static bool GetInputDown (InputAction action,IDevice Device)
				{
					return GetInputDigital ( action, ButtonState.Down,Device);
				}

                public static bool GetInputDigital(int code, ButtonState buttonState, IDevice Device)
				{

						if (code < InputCode.MAX_KEY_CODE) {
								if(buttonState==ButtonState.Down) return InputEx.IGetKeyDown((KeyCode)code);
								if(buttonState==ButtonState.Up) return InputEx.IGetKeyUp((KeyCode)code);
								if(buttonState==ButtonState.Hold) return InputEx.IGetKey((KeyCode)code);
								return false;
				                                                            
						} else {
					
								

								lock (syncRoot) {

										
										if (Device!=null) {


												return Device.GetInputDigital (code, buttonState);


											
										} else {
											
												foreach (IDevice device in Devices)
														if (device.GetInputDigital (code, buttonState))
																return true;
						
												return false;						
						
										}

								}
						}

				}

				private static bool GetInputDigital (InputAction action, ButtonState buttonState,IDevice device)
				{

						return GetInputDigital (action.getCode(device), buttonState,device);

				}

//				private static int GetJoystickInput ()
//				{
//
//
//						int numAxis = 8;
//						float axisValue = 0f;
//						string axisName;
//						KeyCode code;
//		
//						if (_frameCountPrev == Time.frameCount)
//								return 0;
//
//
//						_frameCountPrev = Time.frameCount;
//
//
//
//
//						_numJoysticks = Input.GetJoystickNames ().Length;
//
//
//						//check for joysticks clicks
//						for (int i=0; i<_numJoysticks; i++) {
//				
//						for (int k=0; k < 1; k++) {
//							axisName=i.ToString () + k.ToString ();
//							axisValue = Input.GetAxisRaw(axisName);// + 1f;//index-of joystick, k-ord number of axis
//							
//					Debug.Log("axisValue :"+axisValue);
//
////							if(axisValue>0)
////								return InputCode.toCode((Joysticks)i,(JoystickAxis)k,JoystickPosition.Positive);
////							else if(axisValue<0)
////								return InputCode.toCode((Joysticks)i,(JoystickAxis)k,JoystickPosition.Negative);  
//						}
//					        
//					        
//								//Let Unity handle JoystickButtons
//								for (int j=0; j<_numJoystickButtons; j++) {
//
//										code = (KeyCode)Enum.Parse (typeof(KeyCode), "Joystick" + (i + 1) + "Button" + j);
//
//										//Debug.Log("Joystick"+i+"Button"+j+" code:"+code);
//					          
//										if (Input.GetKeyDown (code)) {
//												return InputCode.toCode ((Joysticks)i, JoystickAxis.None, j);
//
//												// InputCode.toCode(code);
//										}
//								}
//						}
//
//
//						return 0;
//
//
//				}


				/// <summary>
				/// Gets the GUI keyboard input.
				/// first found key or mouse button pressed would be returned
				/// used for mapping states to current input
				/// </summary>
				/// <returns>The GUI keyboard input.</returns>
				private static int GetGUIKeyboardInput ()
				{
						KeyCode keyCode;
						int numKeys = _keys.Length;

						if (_frameCountEditorPrev == _frameCountEditor)
								return 0;
						else
								_frameCountEditorPrev = _frameCountEditor;

			
						for (int i = 0; i < numKeys; i++) {

								//check for mouse clicks
								if (i < _numMouseButtons) {
										keyCode = (KeyCode)Enum.Parse (typeof(KeyCode), "Mouse" + i);

										if (InputEx.GetMouseButtonDown (keyCode)) {
												return (int)keyCode;		
										}
								}
				

								keyCode = _keys [i];//
								if (InputEx.GetKeyDown (keyCode)) {

										return (int)keyCode;
						
								}

						}


						return 0;
				}


		


				/// <summary>
				/// Gets the key(Editor only). Use it in onGUI after processGUIEvent
				/// or in Update but with check of frameCountEditor
				/// <example>
				/// if (_frameCountEditorPrev == _frameCountEditor)
				///  	return 0;
				///  else
				///		_frameCountEditorPrev = _frameCountEditor;
				/// 
				/// </example>
				/// </summary>
				/// <returns><c>true</c>, if key hold, <c>false</c> otherwise.</returns>
				/// <param name="code">Code.</param>
				public static bool GetKey (KeyCode code)
				{
						if (_isKeyState.ContainsKey ((int)code))
								return _isKeyState [(int)code].buttonState == ButtonState.Hold;
			
						return false;

				}


				/// <summary>
				/// Gets the key(Editor only). Use it in onGUI after processGUIEvent
				/// or in Update but with check of frameCountEditor
				/// <example>
				/// if (_frameCountEditorPrev == _frameCountEditor)
				///  	return 0;
				///  else
				///		_frameCountEditorPrev = _frameCountEditor;
				/// 
				/// </example>
				/// </summary>
				/// <returns><c>true</c>, if key was gotten, <c>false</c> otherwise.</returns>
				/// <param name="code">Code.</param>
				public static bool GetMouseButtonDown (KeyCode code)
				{

						return GetKeyDown ((int)code);

				}


				/// <summary>
				/// Gets the key(Editor only). Use it in onGUI after processGUIEvent
				/// or in Update but with check of frameCountEditor
				/// <example>
				/// if (_frameCountEditorPrev == _frameCountEditor)
				///  	return 0;
				///  else
				///		_frameCountEditorPrev = _frameCountEditor;
				/// 
				/// </example>
				/// </summary>
				/// <returns><c>true</c>, if key was gotten, <c>false</c> otherwise.</returns>
				/// <param name="code">Code.</param>
				public static bool GetKeyDown (KeyCode code)
				{
						return GetKeyDown ((int)code);
				}


				/// <summary>
				/// Gets the keyDown(Editor only). Use it in onGUI after processGUIEvent
				/// or in Update but with check of frameCountEditor
				/// <example>
				/// if (_frameCountEditorPrev == _frameCountEditor)
				///  	return 0;
				///  else
				///		_frameCountEditorPrev = _frameCountEditor;
				/// 
				/// </example>
				/// </summary>
				/// <returns><c>true</c>, if key was down, <c>false</c> otherwise.</returns>
				/// <param name="code">Code.</param>
				public static bool GetKeyDown (int code)
				{
						if (_isKeyState.ContainsKey (code))
								return _isKeyState [code].buttonState == ButtonState.Down;
			
						return false;

				}

				/// <summary>
				/// Gets the key(Editor only). Use it in onGUI after processGUIEvent
				/// or in Update but with check of frameCountEditor
				/// <example>
				/// if (_frameCountEditorPrev == _frameCountEditor)
				///  	return 0;
				///  else
				///		_frameCountEditorPrev = _frameCountEditor;
				/// 
				/// </example>
				/// </summary>
				/// <returns><c>true</c>, if key was up, <c>false</c> otherwise.</returns>
				/// <param name="code">Code.</param>
				public static bool GetKeyUp (int code)
				{
						if (_isKeyState.ContainsKey (code))
								return _isKeyState [code].buttonState == ButtonState.Up;
			
						return false;
			
				}

				/// <summary>
				/// Process runtime input
				///  Useful for building Input mapper
				/// </summary>
				protected static int GetKeyboardInput ()
				{

						KeyCode keyCode;




						_button = _key = 0;//KeyCode.None; 

          

						int numKeys = _keys.Length;
						int maxLoops = Mathf.Max (numKeys, _numJoystickButtons);




						for (int i = 0; i < maxLoops; i++) {

								//check for mouse clicks
								if (i < _numMouseButtons) {

										if (Input.GetMouseButtonDown (i)) {
												_button = (KeyCode)Enum.Parse (typeof(KeyCode), "Mouse" + i);
												return (int)_button;

										}
								}

								//check for key clicks
								if (i < numKeys) {
										keyCode = _keys [i];//
										if (Input.GetKeyDown (keyCode)) {
												_key = (KeyCode)keyCode;
												return (int)keyCode;

										}
								}


             




						}




						return 0;



				}

				internal static InputAction GetAction (IDevice device)
				{

						bool isPlaying = Application.isPlaying;

						float time = isPlaying ? Time.time : Time.realtimeSinceStartup;

						//prioterize joysticks vs keys/mouse  
						if (device != null) {
								if ((_code = device.GetInputCode ()) != 0) {
										Debug.Log ("Get Input Just from set device" + device.Index + " " + InputCode.toEnumString (_code) + " frame: " + Time.frameCount);
										return processInputCode (_code, time,device);
								}

							
						} else	
							if (Devices.Count > 0) {
								foreach (IDevice deviceAvailable in Devices) {

										//test only
										//	if(device.Index==3)
										

										if ((_code = deviceAvailable.GetInputCode ()) != 0) {
												Debug.Log ("Get Input Joy" + deviceAvailable.Index + " " + InputCode.toEnumString (_code) + " frame: " + Time.frameCount);
												return processInputCode (_code, time,device);
										}
								}
						} 


						if (isPlaying) {
								_code = InputEx.GetKeyboardInput ();
						} else {
								_code = InputEx.GetGUIKeyboardInput ();
						}



            

						return processInputCode (_code, time,device);
				}

       

				/// <summary>
				/// Check if InputActin happened( SINGLE,DOUBLE,LONG)
				/// </summary>
				/// <returns>true/false</returns>
				/// <param name="action">InputAction to be compared with input</param>
				internal static bool GetAction (InputAction action,IDevice device)
				{

						if (action.type == InputActionType.SINGLE) {
								if (InputEx.GetInputDigital (action, ButtonState.Down,device)) {
										Debug.Log ("Single <" + InputActionType.SINGLE);
										//action.startTime = Time.time;
										_lastCode = action.getCode(device);
										return true;
								}

								return false;
						}


						if (action.type == InputActionType.DOUBLE) {
								if (InputEx.GetInputDigital (action, ButtonState.Down,device)) {
										if (_lastCode != action.getCode(device)) {//first click

												_lastCode = action.getCode(device);
												action.startTime = Time.time;
												Debug.Log ("First Click" + Time.time + ":" + action.startTime + " going for " + InputActionType.DOUBLE);
												return false;
										} else {//InputEx.LastCode==_pointer.Current.code //second click
												//check time diffrence if less then
												if (Time.time - action.startTime < InputAction.DOUBLE_CLICK_SENSITIVITY) {

														_lastCode = 0;//???
														action.startTime = 0;
														Debug.Log ("Double " + Time.time + ":" + action.startTime + "<" + InputActionType.DOUBLE);

														return true;
												}

												// Debug.Log("Lost Double " + Time.time + ":" + action.startTime + "<" + InputActionType.DOUBLE);
										}
								}

								return false;
						}


						if (action.type == InputActionType.LONG) {
								if (InputEx.GetInputDigital (action, ButtonState.Hold,device)) {//if hold
										if (_lastCode != action.getCode(device)) {

												_lastCode = action.getCode(device);

												action.startTime = Time.time;

												return false;
										} else {//InputEx.LastCode==_pointer.Current.getCode(device) //hold
												//check time diffrence if less then
												if (Time.time - action.startTime >= InputAction.LONG_CLICK_SENSITIVITY) {

														_lastCode = 0;//KeyCode.None;
														action.startTime = 0;
														Debug.Log ("Long " + (Time.time - action.startTime) + " " + InputActionType.LONG);

														return true;
												}
										}
								}

								return false;

						}


						return false;


				}


				/// <summary>
				/// Proccess input information returned in Event in onGUI
				/// Useful for building Input mapper editor in "Edit mode"
				/// </summary>
				/// <param name="e">Event dispatched inside onGUI.</param>
				public static void processGUIEvent (Event e)
				{
			
	
			
			
						if ((e.isKey && e.keyCode > 0) || e.isMouse) {
								_frameCountEditor++;
				
								if (e.isMouse)
										_code = (int)Enum.Parse (typeof(KeyCode), "Mouse" + e.button);
								else
										_code = (int)e.keyCode;
				
								bool containsKey = _isKeyState.ContainsKey (_code);
				
								if (!containsKey)
										_isKeyState [_code] = new ButtonDetails ();
				
								//	Debug.Log ("processGUIEvent "+e.keyCode+" "+(int)e.keyCode);
				
				
								//if event is KeyDown and ((if is in keystate tracking should be false (keyup)) or if new not in key state tracking)
								if (e.type == EventType.KeyDown || e.type == EventType.MouseDown) {
					
										_isKeyState [_code].value = 1f;
					
					
										//         Debug.Log ("DOWN :"+e.type+" "+e.keyCode+" buttonState:"+_isKeyState[(int)e.keyCode].buttonState);
					
								} else if (e.type == EventType.KeyUp || e.type == EventType.MouseUp) {
										_isKeyState [_code].value = 0;
					
										//		Debug.Log ("UP :"+e.type+" "+e.keyCode);
					
								}
				
				
								e.Use ();
				
				
						}
			
			
				}

		
		
				/// <summary>
				/// Processes the input code into InputAction
				/// </summary>
				/// <returns>InputAction (single,double,long) or null.</returns>
				/// <param name="code">Code.</param>
				/// <param name="time">Time.</param>
				internal static InputAction processInputCode (int code, float time,IDevice device)
				{


						InputAction action = null;

						// Debug.Log ("process "+code);

						if (code != 0) {//=KeyCode.None 


								if (_lastCode == 0) {//=KeyCode.None
										//save key event and time needed for double check
										_lastCode = code;
										_lastCodeTime = time;

										Debug.Log ("Last code " + InputCode.toEnumString (_lastCode) + " at time:" + _lastCodeTime);
										//	Debug.Log("Take time "+_lastCodeTime);
								} else {
										//if new pressed key is different then the last
										if (_lastCode != code) {
												//consturct string from lastCode
												action = new InputAction (_lastCode, InputActionType.SINGLE,device);

												//take new pressed code as lastCode
												_lastCode = code;

												Debug.Log ("Single " + time + ":" + _lastCodeTime + " " + InputActionType.SINGLE);



										} else {


												if (time - _lastCodeTime < InputAction.DOUBLE_CLICK_SENSITIVITY) {
														action = new InputAction (_lastCode, InputActionType.DOUBLE,device);
														_lastCode = 0;//KeyCode.None;
														Debug.Log ("Double " + time + ":" + _lastCodeTime + "<" + InputActionType.DOUBLE);
												}


										}

								}

						} else {



								if (_lastCode != 0) {//=KeyCode.None
										//if key is still down and time longer then default long time click => display long click
										if (InputEx.GetInputHold (_lastCode,device) || (!Application.isPlaying && InputEx.GetKeyDown (_lastCode))) {
												if (time - _lastCodeTime >= InputAction.LONG_CLICK_SENSITIVITY) {
														action = new InputAction (_lastCode, InputActionType.LONG,device);
														_lastCode = 0;//KeyCode.None;
														Debug.Log ("Long " + (time - _lastCodeTime) + " <" + InputActionType.LONG);
												}
										} else {//time wating for double click activity passed => display last code
												if (time - _lastCodeTime >= InputAction.DOUBLE_CLICK_SENSITIVITY) {
														action = new InputAction (_lastCode, InputActionType.SINGLE,device);
														_lastCode = 0;//KeyCode.None;

														Debug.Log ("Single after wating Double time pass " + (time - _lastCodeTime) + " " + InputActionType.SINGLE);
												}

										}



								}

						}
						return action;
				}


		#region ButtonDetails
				public sealed class ButtonDetails : IButtonDetails
				{
			
			#region Fields
			
						float _value;
						uint _uid;
						ButtonState _buttonState;
						string _name;
			
			#region IDeviceDetails implementation
						public string name {
								get {
										return _name;
								}
								set {
										_name = value;
								}
						}
			
						public uint uid {
								get {
										return _uid;
								}
								set {
										_uid = value;
								}
						}
			
						public ButtonState buttonState {
								get { return _buttonState; }
						}
			
						public float value {
								get {
										return _value;
										//return (_buttonState==ButtonState.Hold || _buttonState==ButtonState.Down);
								}
								set {
					
										_value = value;
					
										//  UnityEngine.Debug.Log("Value:" + _value);
					
										//if pressed==TRUE
										//TODO check the code with triggers
										if (value > 0) {
												if (_buttonState == ButtonState.None
														|| _buttonState == ButtonState.Up) {
							
														_buttonState = ButtonState.Down;
							
							
							
												} else {
														//if (buttonState == ButtonState.Down)
														_buttonState = ButtonState.Hold;
							
												}
						
						
										} else { //
												if (_buttonState == ButtonState.Down
														|| _buttonState == ButtonState.Hold) {
														_buttonState = ButtonState.Up;
												} else {//if(buttonState==ButtonState.Up){
														_buttonState = ButtonState.None;
												}
						
										}
								}//set
						}
			#endregion
			#endregion
			
			#region Constructor
						public ButtonDetails (uint uid = 0)
						{
								this.uid = uid;
						}
			#endregion
			
			
			
			
			
			
				}
		
		#endregion





		}
}

