// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginService.cs" company="bbv Software Services AG">
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
    public class LoginService
    {
        private readonly IUserAuthenticator userAuthenticator;

        public LoginService(IUserAuthenticator userAuthenticator)
        {
            this.userAuthenticator = userAuthenticator;
        }

        public LoginResult Login(string username, string password)
        {
            try
            {
                string token = this.userAuthenticator.Authenticate(username, password);
                return new LoginResult(token, "Login successful");
            }
            catch (WrongPasswordException)
            {
                return new LoginResult(null, "Password wrong");
            }
            catch (UnknownUserException)
            {
                return new LoginResult(null, "User not found");
            }
        }
    }
}