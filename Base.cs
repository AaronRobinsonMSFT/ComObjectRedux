using System.Numerics;

namespace System.Runtime.InteropServices.Marshalling;

/// <summary>
/// Information about a virtual method table and the unmanaged instance pointer.
/// </summary>
public readonly unsafe struct VirtualMethodTableInfo
{
    /// <summary>
    /// Construct a <see cref="VirtualMethodTableInfo"/> from a given instance pointer and table memory.
    /// </summary>
    /// <param name="thisPointer">The pointer to the instance.</param>
    /// <param name="virtualMethodTable">The block of memory that represents the virtual method table.</param>
    public VirtualMethodTableInfo(void* thisPointer, void** virtualMethodTable)
    {
        ThisPointer = thisPointer;
        VirtualMethodTable = virtualMethodTable;
    }

    /// <summary>
    /// The unmanaged instance pointer
    /// </summary>
    public void* ThisPointer { get; }

    /// <summary>
    /// The virtual method table.
    /// </summary>
    public void** VirtualMethodTable { get; }

    /// <summary>
    /// Deconstruct this structure into its two fields.
    /// </summary>
    /// <param name="thisPointer">The <see cref="ThisPointer"/> result</param>
    /// <param name="virtualMethodTable">The <see cref="VirtualMethodTable"/> result</param>
    public void Deconstruct(out void* thisPointer, out void** virtualMethodTable)
    {
        thisPointer = ThisPointer;
        virtualMethodTable = VirtualMethodTable;
    }
}

/// <summary>
/// This interface allows an object to provide information about a virtual method table for a managed interface to enable invoking methods in the virtual method table.
/// </summary>
public unsafe interface IUnmanagedVirtualMethodTableProvider
{
    /// <summary>
    /// Get the information about the virtual method table for a given unmanaged interface type represented by <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The managed type for the unmanaged interface.</param>
    /// <returns>The virtual method table information for the unmanaged interface.</returns>
    public VirtualMethodTableInfo GetVirtualMethodTableInfoForKey(Type type);
}

/// <summary>
/// A factory to create an unmanaged "this pointer" from a managed object and to get a managed object from an unmanaged "this pointer".
/// </summary>
public unsafe interface IUnmanagedObjectWrapperFactory
{
    /// <summary>
    /// Get a pointer that wraps a managed implementation of an unmanaged interface that can be passed to unmanaged code.
    /// </summary>
    /// <param name="obj">The managed object that implements the unmanaged interface.</param>
    /// <returns>A unmanaged "this pointer" that can be passed to unmanaged code that represents <paramref name="obj"/></returns>
    public static abstract void* GetUnmanagedWrapperForObject(object obj);

    /// <summary>
    /// Get the object wrapped by <paramref name="ptr"/>.
    /// </summary>
    /// <param name="ptr">A an unmanaged "this pointer".</param>
    /// <returns>The object wrapped by <paramref name="ptr"/>.</returns>
    public static abstract object GetObjectForUnmanagedWrapper(void* ptr);
}

/// <summary>
/// This interface allows another interface to define that it represents a manavged projection of an unmanaged interface from some unmanaged type system and supports passing managed implementations of unmanaged interfaces to unmanaged code.
/// </summary>
public unsafe interface IUnmanagedInterfaceType
{
    /// <summary>
    /// Get a pointer to the virtual method table of managed implementations of the unmanaged interface type.
    /// </summary>
    /// <returns>A pointer to the virtual method table of managed implementations of the unmanaged interface type</returns>
    /// <remarks>TODO: Source generated</remarks>
    public abstract static void* VirtualMethodTableManagedImplementation { get; }
}

/// <summary>
/// Marshals an exception object to the value of its <see cref="Exception.HResult"/> converted to <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The unmanaged type to convert the HResult to.</typeparam>

// TODO: Update our correctness analyzer to allow a non-generic managed type with a generic marshaller.
// We can determine the correct information at the usage site.
#pragma warning disable SYSLIB1055 // The managed type 'System.Exception' for entry-point marshaller type 'System.Runtime.InteropServices.Marshalling.ExceptionHResultMarshaller<T>' must be a closed generic type, have the same arity as the managed type if it is a value marshaller, or have one additional generic parameter if it is a collection marshaller.

[CustomMarshaller(typeof(Exception), MarshalMode.UnmanagedToManagedOut, typeof(ExceptionHResultMarshaller<>))]
#pragma warning restore SYSLIB1055
public static class ExceptionHResultMarshaller<T>
    where T : unmanaged, INumber<T>
{
    /// <summary>
    /// Marshals an exception object to the value of its <see cref="Exception.HResult"/> converted to <typeparamref name="T"/>.
    /// </summary>
    /// <param name="e">The exception.</param>
    /// <returns>The HResult of the exception, converted to <typeparamref name="T"/>.</returns>
    public static T ConvertToUnmanaged(Exception e)
    {
        // Use GetHRForException to ensure the runtime sets up the IErrorInfo object
        // and calls SetErrorInfo if the platform supports it.

        // We use CreateTruncating here to convert from the int return type of Marshal.GetHRForException
        // to whatever the T is. A "truncating" conversion in this case is the same as an unchecked conversion like
        // (uint)Marshal.GetHRForException(e) would be if we were writing a non-generic marshaller.
        // Since we're using the INumber<T> interface, this is the correct mechanism to represent that conversion.
        return T.CreateTruncating(Marshal.GetHRForException(e));
    }
}

// The analyzer currently doesn't support marshallers where the managed type is 'void'.
#pragma warning disable SYSLIB1057 // The type 'System.Runtime.InteropServices.Marshalling.PreserveSigMarshaller' specifies it supports the 'ManagedToUnmanagedOut' marshal mode, but it does not provide a 'ConvertToManaged' method that takes the unmanaged type as a parameter and returns 'void'.
[CustomMarshaller(typeof(void), MarshalMode.ManagedToUnmanagedOut, typeof(PreserveSigMarshaller))]
#pragma warning restore SYSLIB1057
public static class PreserveSigMarshaller
{
    public static void ConvertToManaged(int hr)
    {
        Marshal.ThrowExceptionForHR(hr);
    }
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class VirtualMethodIndexAttribute : Attribute
{
    public VirtualMethodIndexAttribute(int index)
    {
        Index = index;
    }

    public int Index { get; }

    public bool ImplicitThisParameter { get; set; } = true;

    /// <summary>
    /// Gets or sets how to marshal string arguments to the method.
    /// </summary>
    /// <remarks>
    /// If this field is set to a value other than <see cref="StringMarshalling.Custom" />,
    /// <see cref="StringMarshallingCustomType" /> must not be specified.
    /// </remarks>
    public StringMarshalling StringMarshalling { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Type"/> used to control how string arguments to the method are marshalled.
    /// </summary>
    /// <remarks>
    /// If this field is specified, <see cref="StringMarshalling" /> must not be specified
    /// or must be set to <see cref="StringMarshalling.Custom" />.
    /// </remarks>
    public Type? StringMarshallingCustomType { get; set; }

    /// <summary>
    /// Gets or sets whether the callee sets an error (SetLastError on Windows or errno
    /// on other platforms) before returning from the attributed method.
    /// </summary>
    public bool SetLastError { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Type"/> used to control how an exception is marshalled to the return value.
    /// </summary>
    /// <remarks>
    /// If this field is specified, <see cref="ExceptionMarshalling" /> must not be specified
    /// or must be set to <see cref="ExceptionMarshalling.Custom" />.
    /// </remarks>
    public Type? ExceptionMarshallingType { get; set; }
}

[AttributeUsage(AttributeTargets.Interface)]
public class ObjectUnmanagedMapperAttribute<TMapper> : Attribute
    where TMapper : IUnmanagedObjectWrapperFactory
{
}