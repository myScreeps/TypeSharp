﻿using Ajax;
using System.Reflection;
using Xunit;

namespace TypeSharp.Test
{
    public class TypeScriptModelBuilderTests
    {
        [Fact]
        public void Test1()
        {
            var version = Assembly.LoadFrom("TypeSharp").GetName().Version;
            var builder = new TypeScriptModelBuilder();
            builder.CacheType<RootClass>();
            builder.CacheType<JSend>();

            var tscode = builder.Compile();
            var expectedCode = $@"/* Generated by TypeSharp v{version} */

namespace TSNS1 {{
    export namespace RootClass {{
        export const CONST_STRING : string = 'const_string';
        export const CONST_INTEGER : number = 2147483647;
    }}
}}

declare namespace TSNS1 {{
    interface RootClass {{
        state? : TypeSharp.Test.EState;
        sub? : TSNS2.SubClass;
        subs? : TSNS2.SubClass[];
        str? : string;
        int? : number;
        strArray? : string[];
        nGuid? : string;
    }}
}}
declare namespace TypeSharp.Test {{
    export const enum EState {{
        Ready = 0,
        Running = 1,
        Complete = 2,
    }}
}}
declare namespace TSNS2 {{
    interface SubClass {{
        name? : string;
    }}
}}
declare namespace Ajax {{
    interface JSend {{
        status? : string;
        data? : any;
        code? : string;
        message? : string;
    }}
}}
";
            Assert.Equal(expectedCode, tscode);
        }

        [Fact]
        public void GenericTest()
        {
            var builder = new TypeScriptModelBuilder();
            builder.CacheType(typeof(GenericClass<int>));
            var tscode = builder.Compile();
        }

    }
}
