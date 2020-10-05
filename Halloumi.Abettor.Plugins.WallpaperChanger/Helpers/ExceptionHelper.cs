using System;
using Halloumi.Common.Helpers;

namespace Halloumi.Abettor.Plugins.WallpaperChanger
{
    public static class ExceptionHelper
    {
        #region Public Methods

        /// <summary>
        /// Logs an exception, displays a message to the user, 
        /// and reverts the cursor if neccessary.
        /// </dsummary>
        public static void HandleException(string userErrorMessage, Exception exception)
        {
            // log error to event log
            EventLogHelper.LogError(userErrorMessage, exception);
        }

        /// <summary>
        /// Logs an exception, displays a message to the user, 
        /// and reverts the cursor if neccessary.
        /// </summary>
        public static void HandleException(Exception exception)
        {
            // log error to event log
            EventLogHelper.LogError(exception);
        }

        #endregion  
    }
}
