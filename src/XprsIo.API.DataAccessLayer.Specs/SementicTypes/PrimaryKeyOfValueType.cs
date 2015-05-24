// //////////////////////////////////////////////////////////////////////////////////
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// //////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.SementicTypes;

namespace XprsIo.API.DataAccessLayer.Specs.SementicTypes
{
    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_IEnumerable_of_int_is_an_empty_enumerable_value
    {
        private Because of = () => _exception = Catch.Exception(() => new PrimaryKey<IEnumerable<int>>(Enumerable.Empty<int>()));
        private It should_throw = () => _exception.ShouldBeAssignableTo(typeof(ArgumentOutOfRangeException));

        private static Exception _exception;
    }
    
    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_int_is_set
    {
        private Establish context = () => _subject = new PrimaryKey<int>(42);
        private Because of = () => _value = _subject.Value;
        private It should_return_an_unchanged_value = () => _value.ShouldEqual(42);

        private static PrimaryKey<int> _subject;
        private static int _value;
    }
}