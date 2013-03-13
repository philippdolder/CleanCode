// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarriorBuilder.cs" company="bbv Software Services AG">
//   Copyright (c) 2013
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//   http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Bbv.CleanCodeWorkshop.ExceptionsForControlFlow
{
    using System.Collections.Generic;

    public class UserAuthenticator : IUserAuthenticator
    {
        // username is the key, password is the value
        private readonly IDictionary<string, string> knownUsers;
        private readonly ITokenGenerator tokenGenerator;

        public UserAuthenticator(IDictionary<string, string> knownUsers, ITokenGenerator tokenGenerator)
        {
            this.knownUsers = knownUsers;
            this.tokenGenerator = tokenGenerator;
        }

        public string Authenticate(string username, string password)
        {
            try
            {
                string passwordOfUser = this.knownUsers[username];

                if (passwordOfUser == password)
                {
                    return this.tokenGenerator.Get();
                }
                
                throw new WrongPasswordException();
            }
            catch (KeyNotFoundException)
            {
                throw new UnknownUserException();
            }
        }
    }
}