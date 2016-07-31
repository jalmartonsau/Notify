using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    class Update
    {
        public Update()
        {

        }

        #region DownloadLatest

        /// <summary>
        /// Downloads latest app
        /// </summary>
        public static void DownloadLatest()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return;

            try
            {
                var deployment = ApplicationDeployment.CurrentDeployment;

                if (deployment.CheckForUpdate())
                {
                    deployment.UpdateCompleted += new AsyncCompletedEventHandler(deployment_UpdateCompleted);
                    deployment.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(deployment_UpdateProgress);
                    deployment.UpdateAsync();
                }
            }
            catch (Exception)
            {
                // TODO log exception here.
            }
        }

        #region UpdateCompleted

        /// <summary>
        /// Update Completed, Restart the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void deployment_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }

        #endregion

        #region UpdateProgress

        public static void deployment_UpdateProgress(object sender, DeploymentProgressChangedEventArgs e)
        {
            
        }

        #endregion

        #endregion

    }
}
