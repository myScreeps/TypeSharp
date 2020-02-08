# TypeSharp

C# model to the TypeScript model compiler.

- [Readme: English](https://github.com/zmjack/TypeSharp/blob/master/LICENSE.md)
- [Readme: 中文](https://github.com/zmjack/TypeSharp/blob/master/LICENSE - CN.md)



## How to use

### Use annotation

1. Set **TypeScriptModel** annotation to class：

   ```C#
   [TypeScriptModel(Namespace = "App")]
   public class Cls
   {
        public int Value { get; set; }
   }
   ```

   If **TypeScriptModelAttribute** not set. the namespace is same as the class **Namespace**。

2. Compile to **TypeScript** code：

   ```C#
   var builder = new TypeScriptModelBuilder();
   builder.CacheType<Cls>();
   var tscode = builderCompile();
   ```

   

### Specified directly

1. Define class：

   ```C#
   public class Cls
   {
        public int Value { get; set; }
   }
   ```

2. Compile to **TypeScript** code：

   ```C#
   var builder = new TypeScriptModelBuilder();
   builder.CacheType<Cls>(new TypeScriptModelAttribute { Namespace = "App" });
   var tscode = builderCompile();
   ```

   If **TypeScriptModelAttribute** not set. the namespace is same as the class **Namespace**。



### Output result

```typescript
/* Generated by TypeSharp v0.4.0.0 */

declare namespace App {
    interface Cls {
        value? : number;
    }
}
```

