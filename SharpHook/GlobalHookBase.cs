using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using SharpHook.Native;

namespace SharpHook
{
    /// <summary>
    /// Represents an implementation of the global keyboard and mouse hook which runs the hook on a separate thread and
    /// raises events only when there is at least one subscriber.
    /// </summary>
    public abstract class GlobalHookBase : IGlobalHook
    {
        private bool disposed = false;

        /// <summary>
        /// Unregisteres the global hook if it's registered.
        /// </summary>
        ~GlobalHookBase() =>
            this.Dispose(false);

        /// <summary>
        /// Starts the global hook. The hook can be destroyed by calling the <see cref="IDisposable.Dispose" /> method.
        /// </summary>
        /// <returns>A <see cref="Task" /> which finishes when the hook is destroyed.</returns>
        /// <exception cref="HookException">Starting the global hook has failed.</exception>
        /// <exception cref="ObjectDisposedException">The global hook has been disposed.</exception>
        /// <remarks>
        /// The hook is started on a separate thread.
        /// </remarks>
        [SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "No need to rethrow the exception since it's set as the task source's exception")]
        public Task Start()
        {
            this.ThrowIfDisposed();

            var source = new TaskCompletionSource<object?>();

            var thread = new Thread(() =>
            {
                try
                {
                    UioHook.SetDispatchProc(this.HandleHookEvent);
                    var result = UioHook.Run();

                    if (result == UioHookResult.Success)
                    {
                        source.SetResult(null);
                    } else
                    {
                        source.SetException(new HookException(result, this.FormatFailureMessage("starting", result)));
                    }
                } catch (Exception e)
                {
                    source.SetException(e);
                }
            });

            thread.Start();

            return source.Task;
        }

        /// <summary>
        /// Destroys the global hook.
        /// </summary>
        /// <exception cref="HookException">Stopping the hook has failed.</exception>
        /// <remarks>
        /// After calling this method, the hook cannot be started again. If you want to do that, create a new instance
        /// of <see cref="IGlobalHook" />.
        /// </remarks>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// When implemented in a derived class, represents a strategy for handling the hook event.
        /// </summary>
        /// <param name="e">The event to handle.</param>
        /// <remarks>
        /// Derived classes should call <see cref="DispatchEvent(ref UioHookEvent)" /> inside this method to raise the
        /// appropriate event.
        /// </remarks>
        protected abstract void HandleHookEventInternal(ref UioHookEvent e);

        /// <summary>
        /// Destoys the global hook.
        /// </summary>
        /// <param name="disposing">
        /// <see langword="true" /> if the method is called from the <see cref="Dispose()" /> method.
        /// Otherwise, <see langword="false" />.
        /// </param>
        /// <remarks>
        /// After calling this method, the hook cannot be started again. If you want to do that, create a new instance
        /// of <see cref="IGlobalHook" />.
        /// </remarks>
        /// <exception cref="HookException">Stopping the hook has failed.</exception>
        protected virtual void Dispose(bool disposing)
        {
            this.disposed = true;

            var result = UioHook.Stop();

            if (disposing && result != UioHookResult.Success)
            {
                throw new HookException(result, this.FormatFailureMessage("stopping", result));
            }
        }

        /// <summary>
        /// Dispatches the event from libuiohook, i.e. raises the appropriate event.
        /// </summary>
        /// <param name="e">The event to dispatch.</param>
        protected void DispatchEvent(ref UioHookEvent e)
        {
            switch (e.Type)
            {
                case EventType.HookEnabled:
                    this.HookEnabled?.Invoke(this, new HookEventArgs(e));
                    break;
                case EventType.HookDisabled:
                    this.HookDisabled?.Invoke(this, new HookEventArgs(e));
                    break;
                case EventType.KeyPressed:
                    this.KeyPressed?.Invoke(this, new KeyboardHookEventArgs(e));
                    break;
                case EventType.KeyReleased:
                    this.KeyReleased?.Invoke(this, new KeyboardHookEventArgs(e));
                    break;
                case EventType.MouseClicked:
                    this.MouseClicked?.Invoke(this, new MouseHookEventArgs(e));
                    break;
                case EventType.MousePressed:
                    this.MousePressed?.Invoke(this, new MouseHookEventArgs(e));
                    break;
                case EventType.MouseReleased:
                    this.MouseReleased?.Invoke(this, new MouseHookEventArgs(e));
                    break;
                case EventType.MouseMoved:
                    this.MouseMoved?.Invoke(this, new MouseHookEventArgs(e));
                    break;
                case EventType.MouseDragged:
                    this.MouseDragged?.Invoke(this, new MouseHookEventArgs(e));
                    break;
                case EventType.MouseWheel:
                    this.MouseWheel?.Invoke(this, new MouseWheelHookEventArgs(e));
                    break;
            };
        }

        /// <summary>
        /// Throws an <see cref="ObjectDisposedException" /> if this object is disposed.
        /// </summary>
        /// <param name="method">The method which calls this method.</param>
        protected void ThrowIfDisposed([CallerMemberName] string? method = null)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(
                    this.GetType().Name, $"Cannot call {method} - the object is disposed");
            }
        }

        private void HandleHookEvent(ref UioHookEvent e)
        {
            if (this.ShouldDispatchEvent(ref e))
            {
                this.HandleHookEventInternal(ref e);
            }
        }

        private bool ShouldDispatchEvent(ref UioHookEvent e) =>
            e.Type switch
            {
                EventType.HookEnabled => this.HookEnabled != null,
                EventType.HookDisabled => this.HookDisabled != null,
                EventType.KeyTyped => this.KeyTyped != null,
                EventType.KeyPressed => this.KeyPressed != null,
                EventType.KeyReleased => this.KeyReleased != null,
                EventType.MouseClicked => this.MouseClicked != null,
                EventType.MousePressed => this.MousePressed != null,
                EventType.MouseReleased => this.MouseReleased != null,
                EventType.MouseMoved => this.MouseMoved != null,
                EventType.MouseDragged => this.MouseDragged != null,
                EventType.MouseWheel => this.MouseWheel != null,
                _ => false
            };

        private string FormatFailureMessage(string action, UioHookResult result) =>
            $"Failed {action} the global hook: {result} ({(int)result:x})";

        /// <summary>
        /// An event which is raised when the global hook is enabled.
        /// </summary>
        /// <remarks>This event is raised when the <see cref="Start" /> method is called.</remarks>
        public event EventHandler<HookEventArgs>? HookEnabled;

        /// <summary>
        /// An event which is raised when the global hook is disabled.
        /// </summary>
        public event EventHandler<HookEventArgs>? HookDisabled;

        /// <summary>
        /// An event which is raised when a key is typed.
        /// </summary>
        public event EventHandler<KeyboardHookEventArgs>? KeyTyped;

        /// <summary>
        /// An event which is raised when a key is pressed.
        /// </summary>
        public event EventHandler<KeyboardHookEventArgs>? KeyPressed;

        /// <summary>
        /// An event which is raised when a key is released.
        /// </summary>
        public event EventHandler<KeyboardHookEventArgs>? KeyReleased;

        /// <summary>
        /// An event which is raised when a mouse button is clicked.
        /// </summary>
        public event EventHandler<MouseHookEventArgs>? MouseClicked;

        /// <summary>
        /// An event which is raised when a mouse button is pressed.
        /// </summary>
        public event EventHandler<MouseHookEventArgs>? MousePressed;

        /// <summary>
        /// An event which is raised when a mouse button is released.
        /// </summary>
        public event EventHandler<MouseHookEventArgs>? MouseReleased;

        /// <summary>
        /// An event which is raised when the mouse cursor is moved.
        /// </summary>
        public event EventHandler<MouseHookEventArgs>? MouseMoved;

        /// <summary>
        /// An event which is raised when the mouse cursor is dragged.
        /// </summary>
        public event EventHandler<MouseHookEventArgs>? MouseDragged;

        /// <summary>
        /// An event which is raised when the mouse wheel is turned.
        /// </summary>
        public event EventHandler<MouseWheelHookEventArgs>? MouseWheel;
    }
}