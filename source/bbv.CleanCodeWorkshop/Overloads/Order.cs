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

namespace Bbv.CleanCodeWorkshop.Overloads
{
    using System.Collections.Generic;

    public class Order
    {
        private const string DefaultColor = "black";
        private readonly List<Position> positions = new List<Position>();

        public List<Position> Positions
        {
            get { return this.positions; }
        }

        public void AddPosition(string articleNumber)
        {
            this.AddPosition(articleNumber, 1, string.Empty, DefaultColor);
        }

        public void AddPosition(string articleNumber, int amount)
        {
            this.AddPosition(articleNumber, amount, string.Empty, DefaultColor);
        }

        public void AddPosition(string articleNumber, int amount, string size, string color)
        {
            this.Positions.Add(new Position(articleNumber, amount, size, color));
        }
    }

    public class Position
    {
        public Position(string articleNumber, int amount, string size, string color)
        {
            this.ArticleNumber = articleNumber;
            this.Amount = amount;
            this.Size = size;
            this.Color = color;
        }

        public string ArticleNumber { get; private set; }
        public int Amount { get; private set; }
        public string Size { get; private set; }
        public string Color { get; private set; }
    }
}