namespace InteropWithNative
open System
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<Struct>]
type Point =
    { X: int32
      Y: int32 }

module Native =

    [<DllImport("hello_library")>]
    extern void int_pointer_demo(IntPtr i)

    [<DllImport("hello_library")>]
    extern void char_buffer_demo(IntPtr buffer, IntPtr length)

    [<DllImport("hello_library")>]
    extern void struct_demo(IntPtr pointPtr)

    [<DllImport("hello_library")>]
    extern void struct_buffer_demo(IntPtr buffer, IntPtr length)

module Program =

    let IntPtrDemo() =
        Console.WriteLine("IntPtrDemo")
        let mutable i = 0

        let iPtr = &&i

        Native.int_pointer_demo(NativePtr.toNativeInt iPtr)

        Console.WriteLine(i)

    let CharBufferDemo() =
        Console.WriteLine("CharBufferDemo")

        let mutable length = 0

        let lengthPtr = &&length

        let buffer = Marshal.AllocHGlobal(512)

        Native.char_buffer_demo(buffer, NativePtr.toNativeInt lengthPtr)

        let stringCopiedFromNative = Marshal.PtrToStringAnsi(buffer, length);

        Marshal.FreeHGlobal(buffer)

        Console.WriteLine(stringCopiedFromNative)

    let StructDemo() =
        Console.WriteLine("StructDemo")

        let mutable p = { X = 0; Y = 0 }

        let pPtr = &&p

        Native.struct_demo(NativePtr.toNativeInt pPtr)

        Console.WriteLine(p)

    let StructBufferDemo() =
        Console.WriteLine("StructBufferDemo")

        let size = Marshal.SizeOf(typeof<Point>)

        let buffer = Marshal.AllocHGlobal(size * 25)

        let mutable length = 0

        let lengthPtr = &&length

        Native.struct_buffer_demo(buffer, NativePtr.toNativeInt lengthPtr)

        Console.WriteLine(length)


        let (result: Point[]) = Array.zeroCreate length

        for i in 0 .. length - 1 do
            let structIndex: nativeint = buffer + (nativeint i * nativeint size)
            result.[i] <- Marshal.PtrToStructure<Point>(structIndex)

        Console.WriteLine(sprintf "%A" result)


    [<EntryPoint>]
    let Main(args) =

        IntPtrDemo()
        CharBufferDemo()
        StructDemo()
        StructBufferDemo()

        0