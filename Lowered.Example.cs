using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Lowered;

// This file shows how the concept of the generated COM interfaces would be represented using VirtualMethodIndexAttribute directly.
// It's excluded from the compilation as it depends on the generator providing the implementation and I didn't want to have two implementations of the same generated code.

[IUnknownDerived<IComInterface1, Impl>]
[ObjectUnmanagedMapper<ComWrappersWrapperFactory<MyGeneratedComWrappers>>]
public partial interface IComInterface1 : IUnmanagedInterfaceType, IIUnknownInterfaceType
{
    [VirtualMethodIndex(3)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
    [return: MarshalUsing(typeof(PreserveSigMarshaller))]
    void Method();

    internal partial interface Impl : IComInterface1 {}
}

[IUnknownDerived<IComInterface2, Impl>]
[ObjectUnmanagedMapper<ComWrappersWrapperFactory<MyGeneratedComWrappers>>]
public partial interface IComInterface2 : IUnmanagedInterfaceType, IIUnknownInterfaceType
{
    [VirtualMethodIndex(3)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
    [return: MarshalUsing(typeof(PreserveSigMarshaller))]
    void Method1();

    [VirtualMethodIndex(4)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
    [return: MarshalUsing(typeof(PreserveSigMarshaller))]
    void Method2();

    internal partial interface Impl : IComInterface2 {}
}

[IUnknownDerived<IComInterface3, Impl>]
[ObjectUnmanagedMapper<ComWrappersWrapperFactory<MyGeneratedComWrappers>>]
public partial interface IComInterface3 : IUnmanagedInterfaceType, IIUnknownInterfaceType
{
    [VirtualMethodIndex(3)]
    [UnmanagedCallConv(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
    [return: MarshalUsing(typeof(PreserveSigMarshaller))]
    void Method();

    internal partial interface Impl : IComInterface3 {}
}
