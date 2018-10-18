using System;
using System.Reflection;
using System.Windows.Input;
using System.Collections.Generic;

namespace XFArchitecture.Core.Utilities
{
    public sealed class Command<T> : Command
    {
        public Command(Action<T> execute)
            : base(o =>
            {
                if (IsValidParameter(o))
                {
                    execute((T)o);
                }
            })
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }

        public Command(Action<T> execute, Func<T, bool> canExecute)
            : base(o =>
            {
                if (IsValidParameter(o))
                {
                    execute((T)o);
                }
            }, o => IsValidParameter(o) && canExecute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        static bool IsValidParameter(object o)
        {
            if (o != null)
            {
                // The parameter isn't null, so we don't have to worry whether null is a valid option
                return o is T;
            }

            var t = typeof(T);

            // The parameter is null. Is T Nullable?
            if (Nullable.GetUnderlyingType(t) != null)
            {
                return true;
            }

            // Not a Nullable, if it's a value type then null is not valid
            return !t.GetTypeInfo().IsValueType;
        }
    }

    public class Command : ICommand
    {
        readonly Func<object, bool> _canExecute;
        readonly Action<object> _execute;
        readonly WeakEventManager _weakEventManager = new WeakEventManager();

        public Command(Action<object> execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
        }

        public Command(Action execute) : this(o => execute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        public Command(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));

            _canExecute = canExecute;
        }

        public Command(Action execute, Func<bool> canExecute) : this(o => execute(), o => canExecute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { _weakEventManager.AddEventHandler(nameof(CanExecuteChanged), value); }
            remove { _weakEventManager.RemoveEventHandler(nameof(CanExecuteChanged), value); }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void ChangeCanExecute()
        {
            _weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));
        }
    }

    internal class WeakEventManager
    {
        readonly Dictionary<string, List<Subscription>> _eventHandlers =
            new Dictionary<string, List<Subscription>>();

        public void AddEventHandler<TEventArgs>(string eventName, EventHandler<TEventArgs> handler)
            where TEventArgs : EventArgs
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            AddEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        public void AddEventHandler(string eventName, EventHandler handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            AddEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        public void HandleEvent(object sender, object args, string eventName)
        {
            var toRaise = new List<Tuple<object, MethodInfo>>();
            var toRemove = new List<Subscription>();

            List<Subscription> target;
            if (_eventHandlers.TryGetValue(eventName, out target))
            {
                foreach (Subscription subscription in target)
                {
                    bool isStatic = subscription.Subscriber == null;
                    if (isStatic)
                    {
                        // For a static method, we'll just pass null as the first parameter of MethodInfo.Invoke
                        toRaise.Add(Tuple.Create<object, MethodInfo>(null, subscription.Handler));
                        continue;
                    }

                    object subscriber = subscription.Subscriber.Target;

                    if (subscriber == null)
                    {
                        // The subscriber was collected, so there's no need to keep this subscription around
                        toRemove.Add(subscription);
                    }
                    else
                    {
                        toRaise.Add(Tuple.Create(subscriber, subscription.Handler));
                    }
                }

                foreach (Subscription subscription in toRemove)
                {
                    target.Remove(subscription);
                }
            }

            foreach (Tuple<object, MethodInfo> tuple in toRaise)
            {
                tuple.Item2.Invoke(tuple.Item1, new[] { sender, args });
            }
        }

        public void RemoveEventHandler<TEventArgs>(string eventName, EventHandler<TEventArgs> handler)
            where TEventArgs : EventArgs
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            RemoveEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        public void RemoveEventHandler(string eventName, EventHandler handler)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            RemoveEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        void AddEventHandler(string eventName, object handlerTarget, MethodInfo methodInfo)
        {
            List<Subscription> targets;
            if (!_eventHandlers.TryGetValue(eventName, out targets))
            {
                targets = new List<Subscription>();
                _eventHandlers.Add(eventName, targets);
            }

            if (handlerTarget == null)
            {
                // This event handler is a static method
                targets.Add(new Subscription(null, methodInfo));
                return;
            }

            targets.Add(new Subscription(new WeakReference(handlerTarget), methodInfo));
        }

        void RemoveEventHandler(string eventName, object handlerTarget, MemberInfo methodInfo)
        {
            List<Subscription> subscriptions;
            if (!_eventHandlers.TryGetValue(eventName, out subscriptions))
            {
                return;
            }

            for (int n = subscriptions.Count; n > 0; n--)
            {
                Subscription current = subscriptions[n - 1];

                if (current.Subscriber?.Target != handlerTarget
                    || current.Handler.Name != methodInfo.Name)
                {
                    continue;
                }

                subscriptions.Remove(current);
            }
        }

        struct Subscription
        {
            public Subscription(WeakReference subscriber, MethodInfo handler)
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                Subscriber = subscriber;
                Handler = handler;
            }

            public readonly WeakReference Subscriber;
            public readonly MethodInfo Handler;
        }
    }
}
