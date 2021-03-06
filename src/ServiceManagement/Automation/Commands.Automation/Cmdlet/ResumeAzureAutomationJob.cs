﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// Resumes an azure automation job.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Resume, "AzureAutomationJob")]
    public class ResumeAzureAutomationJob : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The job id.")]
        [Alias("JobId")]
        public Guid Id { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            this.AutomationClient.ResumeJob(this.AutomationAccountName, this.Id);
        }
    }
}
