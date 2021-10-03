using System;
using System.Threading.Tasks;

namespace SharpHook
{
    /// <summary>
    /// Represents a global keyboard and mouse hook.
    /// </summary>
    public interface IGlobalHook : IDisposable
    {
        /// <summary>
        /// Starts the global hook. The hook can be destroyed by calling the <see cref="IDisposable.Dispose" /> method.
        /// </summary>
        /// <returns>A <see cref="Task" /> which finishes when the hook is destroyed.</returns>
        Task Start();

        /// <summary>
        /// An event which is raised when a key is typed.
        /// </summary>
        event EventHandler<KeyboardHookEventArgs> KeyTyped;

        /// <summary>
        /// An event which is raised when a key is pressed.
        /// </summary>
        event EventHandler<KeyboardHookEventArgs> KeyPressed;

        /// <summary>
        /// An event which is raised when a key is released.
        /// </summary>
        event EventHandler<KeyboardHookEventArgs> KeyReleased;

        /// <summary>
        /// An event which is raised when a mouse button is clicked.
        /// </summary>
        event EventHandler<MouseHookEventArgs> MouseClicked;

        /// <summary>
        /// An event which is raised when a mouse button is pressed.
        /// </summary>
        event EventHandler<MouseHookEventArgs> MousePressed;

        /// <summary>
        /// An event which is raised when a mouse button is released.
        /// </summary>
        event EventHandler<MouseHookEventArgs> MouseReleased;

        /// <summary>
        /// An event which is raised when the mouse cursor is moved.
        /// </summary>
        event EventHandler<MouseHookEventArgs> MouseMoved;

        /// <summary>
        /// An event which is raised when the mouse cursor is dragged.
        /// </summary>
        event EventHandler<MouseHookEventArgs> MouseDragged;

        /// <summary>
        /// An event which is raised when the mouse wheel is turned.
        /// </summary>
        event EventHandler<MouseWheelHookEventArgs> MouseWheel;
    }
}
