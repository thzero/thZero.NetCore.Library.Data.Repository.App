/* ------------------------------------------------------------------------- *
thZero.NetCore.Library.Data.Repository.App
Copyright (C) 2021-2022 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using System;
using System.Threading.Tasks;

using thZero.Data;
using thZero.Instrumentation;
using thZero.Requests;
using thZero.Responses.Users;

namespace thZero.Repositories.Users
{
    public interface IBaseUserRepository<TUserRequest, TUserResponse, TUserData, TPlanData, TUserSettings>
		where TUserRequest : BaseUserRequest
		where TUserResponse : BaseUserResponse<TUserData, TUserSettings, TPlanData>
		where TUserData : BaseUserData<TUserSettings, TPlanData>
		where TPlanData : BasePlanData
	{
		Task<TUserResponse> FetchAsync(IInstrumentationPacket instrumentation, string userId, bool excludePlan = false);

		Task<TUserResponse> FetchByExternalIdAsync(IInstrumentationPacket instrumentation, string externalUserId, bool excludePlan = false);

		Task RefreshSettingsAsync(IInstrumentationPacket instrumentation, object parameters);

		Task<TUserResponse> UpdateFromExternalAsync(IInstrumentationPacket instrumentation, string userId, TUserData user);

		Task UpdateSettingsAsync(IInstrumentationPacket instrumentation, object requestedSettings);
	}
}
