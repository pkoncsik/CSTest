
using System;
using System.Windows; 
using System.Windows.Threading;



namespace CSTest.Shared.UIHelper
{
    public static class Execute
    {


        private static Action<Action> _executor =action  =>action();


        /// <summary>
        /// Initializes the framework using the current dispatcher.


        /// </summary> 

        public static void InitializeWithDispatcher()

        {

            _executor = action =>

            {
                var dispatcher = GetDispatcher();
                if (dispatcher == null)
                { //Dispatcher does not exist, so task cannot run 
                    return;
                }
                if (dispatcher.CheckAccess())
                {
                    action();
                    return;
                }
                dispatcher.Invoke(action);
            };
        }

        private static Dispatcher GetDispatcher()
        {            
            return Application.Current == null  ? null
                : Application.Current.Dispatcher;
        }

        /// <summary>
        /// Resets the executor to use a non-dispatcher-based action executor.
        /// </summary> 

        public static void ResetWithoutDispatcher()

        {
            _executor = action => action();
        }

        /// <summary>
        /// Executes the action on the UI thread.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        public static void OnUiThread(this Action action)
        {
            _executor(action);
        }
    }
}

