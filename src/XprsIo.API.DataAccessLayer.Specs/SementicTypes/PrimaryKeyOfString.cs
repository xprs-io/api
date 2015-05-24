// //////////////////////////////////////////////////////////////////////////////////&#xD;
// Licensed under the Apache License, Version 2.0 (the "License");&#xD;
// you may not use this file except in compliance with the License.&#xD;
// You may obtain a copy of the License at&#xD;
// &#xD;
//     http://www.apache.org/licenses/LICENSE-2.0&#xD;
// &#xD;
// Unless required by applicable law or agreed to in writing, software&#xD;
// distributed under the License is distributed on an "AS IS" BASIS,&#xD;
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.&#xD;
// See the License for the specific language governing permissions and&#xD;
// limitations under the License.&#xD;
// //////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using XprsIo.API.DataAccessLayer.SementicTypes;

namespace XprsIo.API.DataAccessLayer.Specs.SementicTypes
{
    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_string_is_a_null_value
    {
        private Because of = () => _exception = Catch.Exception(() =>new PrimaryKey<string>(null));
        private It should_throw = () => _exception.ShouldBeAssignableTo(typeof (ArgumentNullException));

        private static Exception _exception;
    }

    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_string_is_empty
    {
        private Because of = () => _exception = Catch.Exception(() => new PrimaryKey<string>(string.Empty));
        private It should_throw = () => _exception.ShouldBeAssignableTo(typeof(ArgumentOutOfRangeException));

        private static Exception _exception;
    }

    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_string_is_set
    {
        private Establish context = () => _subject = new PrimaryKey<string>("foo");
        private Because of = () => _value = _subject.Value;
        private It should_return_an_unchanged_value = () => _value.ShouldEqual("foo");

        private static PrimaryKey<string> _subject;
        private static string _value;
    }

    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_IEnumerable_of_string_is_an_empty_enumerable_value
    {
        private Establish context = () => _source = Enumerable.Empty<string>();
        private Because of = () => _exception = Catch.Exception(() => new PrimaryKey<IEnumerable<string>>(_source));
        private It should_throw = () => _exception.ShouldBeAssignableTo(typeof(ArgumentOutOfRangeException));

        private static IEnumerable<string> _source;
        private static Exception _exception;
    }

    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_IEnumerable_of_string_is_set_with_one_value
    {
        private Establish context = () =>
        {
            _source = Enumerable.Range(0, 1).Select(i => i.ToString());
            _subject = new PrimaryKey<IEnumerable<string>>(_source);
        };
        private Because of = () => _value = _subject.Value;
        private It should_return_an_unchanged_value = () => _value.ShouldBeTheSameAs(_subject);

        private static IEnumerable<string> _source;
        private static PrimaryKey<IEnumerable<string>> _subject;
        private static IEnumerable<string> _value;
    }

    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_IEnumerable_of_string_is_set_with_three_values
    {
        private Establish context = () =>
        {
            _source = Enumerable.Range(0, 3).Select(i => i.ToString());
            _subject = new PrimaryKey<IEnumerable<string>>(_source);
        };
        private Because of = () => _value = _subject.Value;
        private It should_return_an_unchanged_value = () => _value.ShouldBeTheSameAs(_subject);

        private static IEnumerable<string> _source;
        private static PrimaryKey<IEnumerable<string>> _subject;
        private static IEnumerable<string> _value;
    }

    [Subject(typeof(PrimaryKey<>), Categories.SemanticTypes)]
    public class When_PrimaryKey_of_IEnumerable_of_string_is_set_with_a_thousand_values
    {
        private Establish context = () =>
        {
            _source = Enumerable.Range(0, 1000).Select(i => i.ToString());
            _subject = new PrimaryKey<IEnumerable<string>>(_source);
        };
        private Because of = () => _value = _subject.Value;
        private It should_return_an_unchanged_value = () => _value.ShouldBeTheSameAs(_subject);

        private static IEnumerable<string> _source;
        private static PrimaryKey<IEnumerable<string>> _subject;
        private static IEnumerable<string> _value;
    }
}