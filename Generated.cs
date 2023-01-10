using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

file abstract unsafe class IUnknownVTableComWrappers : ComWrappers
{
	public static void GetIUnknownImpl(out void* pQueryInterface, out void* pAddRef, out void* pRelease)
    {
		nint qi, addRef, release;
        ComWrappers.GetIUnknownImpl(out qi, out addRef, out release);
        pQueryInterface = (void*)qi;
        pAddRef = (void*)addRef;
        pRelease = (void*)release;
    }
}

internal sealed partial class MyGeneratedComWrappers : GeneratedComWrappersBase
{
    protected override unsafe ComInterfaceEntry* ComputeVtables(object obj, CreateComInterfaceFlags flags, out int count)
        => throw new NotImplementedException();
}

[IUnknownDerived<IComInterface1, Impl>]
public unsafe partial interface IComInterface1 : IUnmanagedInterfaceType, IIUnknownInterfaceType
{
    static Guid IIUnknownInterfaceType.Iid => new Guid("2c3f9903-b586-46b1-881b-adfce9af47b1");

    private static readonly void** m_vtable = (void**)RuntimeHelpers.AllocateTypeAssociatedMemory(typeof(IComInterface1), sizeof(void*) * 4);

    static void* IUnmanagedInterfaceType.VirtualMethodTableManagedImplementation
    {
        get
        {
            if (m_vtable[0] == null)
            {
                IUnknownVTableComWrappers.GetIUnknownImpl(out m_vtable[0], out m_vtable[1], out m_vtable[2]);
                Impl.PopulateManagedVirtualMethodTable(m_vtable);
            }
            return m_vtable;
        }
    }

    [DynamicInterfaceCastableImplementation]
    internal interface Impl : IComInterface1
    {
        internal static void PopulateManagedVirtualMethodTable(void* table)
        {
            var vtable = (void**)table;
            vtable[3] = (delegate* unmanaged[Stdcall, MemberFunction]<void*, int>)&ABI_Method;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
        private static int ABI_Method(void* thisPtr)
        {
            int retVal = 0;
            try
            {
                IComInterface1 @this = (IComInterface1)ComWrappersWrapperFactory<MyGeneratedComWrappers>.GetObjectForUnmanagedWrapper(thisPtr);
                @this.Method();
            }
            catch (System.Exception ex)
            {
                retVal = ExceptionHResultMarshaller<int>.ConvertToUnmanaged(ex);
            }
            return retVal;
        }

        void IComInterface1.Method()
        {
            var (thisPtr, vtable) = ((IUnmanagedVirtualMethodTableProvider)this).GetVirtualMethodTableInfoForKey(typeof(IComInterface1));
            int hr = ((delegate* unmanaged<void*, int>)vtable[3])(thisPtr);
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }
        }
    }
}

[IUnknownDerived<IComInterface2, Impl>]
public unsafe partial interface IComInterface2 : IUnmanagedInterfaceType, IIUnknownInterfaceType
{
    static Guid IIUnknownInterfaceType.Iid => new Guid("2c3f9903-b586-46b1-881b-adfce9af47b2");

    private static readonly void** m_vtable = (void**)RuntimeHelpers.AllocateTypeAssociatedMemory(typeof(IComInterface1), sizeof(void*) * 5);

    static void* IUnmanagedInterfaceType.VirtualMethodTableManagedImplementation
    {
        get
        {
            if (m_vtable[0] == null)
            {
                IUnknownVTableComWrappers.GetIUnknownImpl(out m_vtable[0], out m_vtable[1], out m_vtable[2]);
                Impl.PopulateManagedVirtualMethodTable(m_vtable);
            }
            return m_vtable;
        }
    }

    [DynamicInterfaceCastableImplementation]
    internal interface Impl : IComInterface2
    {
        internal static void PopulateManagedVirtualMethodTable(void* table)
        {
            var vtable = (void**)table;
            vtable[3] = (delegate* unmanaged[Stdcall, MemberFunction]<void*, int>)&ABI_Method1;
            vtable[4] = (delegate* unmanaged[Stdcall, MemberFunction]<void*, int>)&ABI_Method2;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
        private static int ABI_Method1(void* thisPtr)
        {
            int retVal = 0;
            try
            {
                IComInterface2 @this = (IComInterface2)ComWrappersWrapperFactory<MyGeneratedComWrappers>.GetObjectForUnmanagedWrapper(thisPtr);
                @this.Method1();
            }
            catch (System.Exception ex)
            {
                retVal = ExceptionHResultMarshaller<int>.ConvertToUnmanaged(ex);
            }
            return retVal;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
        private static int ABI_Method2(void* thisPtr)
        {
            int retVal = 0;
            try
            {
                IComInterface2 @this = (IComInterface2)ComWrappersWrapperFactory<MyGeneratedComWrappers>.GetObjectForUnmanagedWrapper(thisPtr);
                @this.Method2();
            }
            catch (System.Exception ex)
            {
                retVal = ExceptionHResultMarshaller<int>.ConvertToUnmanaged(ex);
            }
            return retVal;
        }

        void IComInterface2.Method1()
        {
            unsafe
            {
                var (thisPtr, vtable) = ((IUnmanagedVirtualMethodTableProvider)this).GetVirtualMethodTableInfoForKey(typeof(IComInterface2));
                int hr = ((delegate* unmanaged<void*, int>)vtable[3])(thisPtr);
                if (hr < 0)
                {
                    Marshal.ThrowExceptionForHR(hr);
                }
            }
        }
        void IComInterface2.Method2()
        {
            unsafe
            {
                var (thisPtr, vtable) = ((IUnmanagedVirtualMethodTableProvider)this).GetVirtualMethodTableInfoForKey(typeof(IComInterface2));
                int hr = ((delegate* unmanaged<void*, int>)vtable[4])(thisPtr);
                if (hr < 0)
                {
                    Marshal.ThrowExceptionForHR(hr);
                }
            }
        }
    }
}

[IUnknownDerived<IComInterface3, Impl>]
public unsafe partial interface IComInterface3 : IUnmanagedInterfaceType, IIUnknownInterfaceType
{
    static Guid IIUnknownInterfaceType.Iid => new Guid("2c3f9903-b586-46b1-881b-adfce9af47b3");


    private static readonly void** m_vtable = (void**)RuntimeHelpers.AllocateTypeAssociatedMemory(typeof(IComInterface3), sizeof(void*) * 4);

    static void* IUnmanagedInterfaceType.VirtualMethodTableManagedImplementation
    {
        get
        {
            if (m_vtable[0] == null)
            {
                IUnknownVTableComWrappers.GetIUnknownImpl(out m_vtable[0], out m_vtable[1], out m_vtable[2]);
                Impl.PopulateManagedVirtualMethodTable(m_vtable);
            }
            return m_vtable;
        }
    }

    [DynamicInterfaceCastableImplementation]
    internal interface Impl : IComInterface3
    {
        internal static void PopulateManagedVirtualMethodTable(void* table)
        {
            var vtable = (void**)table;
            vtable[3] = (delegate* unmanaged[Stdcall, MemberFunction]<void*, int>)&ABI_Method;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall), typeof(CallConvMemberFunction) })]
        private static int ABI_Method(void* thisPtr)
        {
            int retVal = 0;
            try
            {
                IComInterface3 @this = (IComInterface3)ComWrappersWrapperFactory<MyGeneratedComWrappers>.GetObjectForUnmanagedWrapper(thisPtr);
                @this.Method();
            }
            catch (System.Exception ex)
            {
                retVal = ExceptionHResultMarshaller<int>.ConvertToUnmanaged(ex);
            }
            return retVal;
        }

        void IComInterface3.Method()
        {
            unsafe
            {
                var (thisPtr, vtable) = ((IUnmanagedVirtualMethodTableProvider)this).GetVirtualMethodTableInfoForKey(typeof(IComInterface3));
                int hr = ((delegate* unmanaged<void*, int>)vtable[3])(thisPtr);
                if (hr < 0)
                {
                    Marshal.ThrowExceptionForHR(hr);
                }
            }
        }
    }
}