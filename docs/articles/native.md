# Native Functions

This article describes how to use the low-level stuff provided by SharpHook.

SharpHook exposes the methods of libuiohook in the `SharpHook.Native.UioHook` class. The `SharpHook.Native`
namespace also contains structs and enums which represent the data returned by libuiohook.

In general, you shouldn't use native methods directly. Instead, use the higher-level interfaces and classes provided by
SharpHook. However, you should still read this article to know how the high-level features work under the hood.

## Working with the Hook Itself

`UioHook` contains the following methods for working with the global hook:

- `SetDispatchProc` (`hook_set_dispatch_proc`) - sets the function which will be called when an event is raised by
libuiohook.
- `Run` (`hook_run`) - creates a global hook and runs it on the current thread, blocking it until `Stop` is called.
- `Stop` (`hook_stop`) - destroys the global hook.

You have to remember that only one global hook can exist at a time since calling `SetDispatchProc` will override the
previously set one.

`SetDispatchProc` accepts a delegate of type `SharpHook.Native.DispatchProc`. This delegate in turn accepts a
`SharpHook.Native.UioHookEvent` by reference, and returns nothing. `UioHookEvent` contains information about
the event that has occured.

There are several event types supported by libuiohook (defined in the `SharpHook.Native.EventType` enum).

Following are the general-purpose events:

- `HookEnabled` - raised when the `Run` method is called.
- `HookDisabled` - raised when the `Stop` method is called.

Following are the keyboard events, and `UioHookEvent` will contain more infomration in its `Keyboard` field:

- `KeyPressed` - raised when a key is pressed.
- `KeyReleased` - raised when a key is released.
- `KeyTyped` - raised when a character is typed using the keyboard.

Following are the mouse events, and `UioHookEvent` will contain more infomration in its `Mouse` field:

- `MouseClicked` - raised when a mouse button is clicked.
- `MousePressed` - raised when a mouse button is pressed.
- `MouseReleased` - raised when a mouse button is released.
- `MouseMoved` - raised when the mouse cursor is moved.
- `MouseDragged` - raised when the mouse cursor is dragged.
- `MouseWheel` - raised when the mouse wheel is scrolled.

The last event is different from the others in that when it's raised, it's information will be contained in the `Wheel`
field of `UioHookEvent` since it contains more information.

## Other Functions

libuiohooks also provides functions which get various pieces of information about the system, and are listed below:

- `CreateScreenInfo` (`hook_create_screen_info`)
- `GetAutoRepeatRate` (`hook_get_auto_repeat_rate`)
- `GetAutoRepeatDelay` (`hook_get_auto_repeat_delay`)
- `GetPointerAccelerationMultiplier` (`hook_get_pointer_acceleration_multiplier`)
- `GetPointerAccelerationThreshold` (`hook_get_pointer_acceleration_threshold`)
- `GetPointerSensitivity` (`hook_get_pointer_sensitivity`)
- `GetMultiClickTime` (`hook_get_multi_click_time`)

These functions are quite straightforward, except for `CreateScreenInfo`. `UioHook` defines two versions of this
function. One is the native function which returns an unmanaged array of `ScreenData` objects (as an `IntPtr`) along
with its length in an output parameter. Another is a wrapper which returs a managed array. Use the second one if you
need it since it's safer.

Next article: [Global Hooks](hooks.md).