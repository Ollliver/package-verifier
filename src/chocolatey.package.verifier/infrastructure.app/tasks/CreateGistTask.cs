﻿// <copyright company="RealDimensions Software, LLC" file="CreateGistTask.cs">
//   Copyright 2015 - Present RealDimensions Software, LLC
// </copyright>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace chocolatey.package.verifier.Infrastructure.App.Tasks
{
    using System;
    using Infrastructure.App.Messaging;
    using Infrastructure.Messaging;
    using Infrastructure.Tasks;

    public class CreateGistTask : ITask
    {
        private IDisposable subscription;

        public void Initialize()
        {
            this.subscription = EventManager.Subscribe<CreateGistMessage>(this.CreateGist, null, null);
            this.Log().Info(() => "{0} is now ready and waiting for CreateGistMessage".FormatWith(GetType().Name));
        }

        public void Shutdown()
        {
            if (this.subscription != null)
            {
                this.subscription.Dispose();
            }
        }

        private void CreateGist(CreateGistMessage message)
        {
            this.Log().Info(() => "Creating gist with install log from: {0} and uninstall log from: {1}".FormatWith(message.InstallationLog, message.UninstallationLog));
        }
    }
}