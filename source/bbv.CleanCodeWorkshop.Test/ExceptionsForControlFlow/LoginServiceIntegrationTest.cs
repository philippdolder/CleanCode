// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginServiceIntegrationTest.cs" company="bbv Software Services AG">
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
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class LoginServiceIntegrationTest
    {
        private IDictionary<string, string> knownUsers;
        private LoginService testee;
        private ITokenGenerator tokenGenerator;

        [SetUp]
        public void SetUp()
        {
            this.knownUsers = new Dictionary<string, string>();
            this.tokenGenerator = A.Fake<ITokenGenerator>();

            this.testee = new LoginService(this.knownUsers, this.tokenGenerator);
        }

        [Test]
        public void ReturnsSession()
        {
            const string Username = "User";
            const string Password = "Password";
            const string SessionToken = "123456789";

            this.knownUsers.Add(Username, Password);
            A.CallTo(() => this.tokenGenerator.Get()).Returns(SessionToken);

            LoginResult loginResult = this.testee.Login(Username, Password);

            loginResult.Should().NotBeNull();
            loginResult.Token.Should().Be(SessionToken);
            loginResult.Message.Should().Be("Login successful");
        }

        [Test]
        public void ReturnsNoSession_WhenPasswordIsWrong()
        {
            const string Username = "User";
            const string WrongPassword = "wrong";

            this.knownUsers.Add(Username, "Password");

            LoginResult loginResult = this.testee.Login(Username, WrongPassword);

            loginResult.Message.Should().Be("Password wrong");
        }

        [Test]
        public void ReturnsNoSession_WhenUserDoesNotExist()
        {
            const string UnknownUsername = "invalid user";

            LoginResult loginResult = this.testee.Login(UnknownUsername, string.Empty);

            loginResult.Message.Should().Be("User not found");
        }
    }
}