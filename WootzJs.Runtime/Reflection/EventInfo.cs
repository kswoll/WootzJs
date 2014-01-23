namespace System.Reflection
{
    /// <summary>
    /// Discovers the attributes of an event and provides access to event metadata.
    /// </summary>
    public class EventInfo : MemberInfo
    {
        private Type eventType;
        private MethodInfo addMethod;
        private MethodInfo removeMethod;

        public EventInfo(string name, Type eventType, MethodInfo addMethod, MethodInfo removeMethod, Attribute[] attributes) : base(name, attributes)
        {
            this.eventType = eventType;
            this.addMethod = addMethod;
            this.removeMethod = removeMethod;
        }

        /// <summary>
        /// Gets a <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is an event.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MemberTypes"/> value indicating that this member is an event.
        /// </returns>
        public override MemberTypes MemberType
        {
            get { return MemberTypes.Event; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Reflection.MethodInfo"/> object for the <see cref="M:System.Reflection.EventInfo.AddEventHandler(System.Object,System.Delegate)"/> method of the event, including non-public methods.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Reflection.MethodInfo"/> object for the <see cref="M:System.Reflection.EventInfo.AddEventHandler(System.Object,System.Delegate)"/> method.
        /// </returns>
        public virtual MethodInfo AddMethod
        {
            get { return addMethod; }
        }

        /// <summary>
        /// Gets the MethodInfo object for removing a method of the event, including non-public methods.
        /// </summary>
        /// 
        /// <returns>
        /// The MethodInfo object for removing a method of the event.
        /// </returns>
        public virtual MethodInfo RemoveMethod
        {
            get { return removeMethod; }
        }

        /// <summary>
        /// Gets the Type object of the underlying event-handler delegate associated with this event.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only Type object representing the delegate event handler.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public virtual Type EventHandlerType
        {
            get { return eventType; }
        }

        /// <summary>
        /// When overridden in a derived class, retrieves the MethodInfo object for the <see cref="M:System.Reflection.EventInfo.AddEventHandler(System.Object,System.Delegate)"/> method of the event, specifying whether to return non-public methods.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MethodInfo"/> object representing the method used to add an event handler delegate to the event source.
        /// </returns>
        /// <param name="nonPublic">true if non-public methods can be returned; otherwise, false. </param><exception cref="T:System.MethodAccessException"><paramref name="nonPublic"/> is true, the method used to add an event handler delegate is non-public, and the caller does not have permission to reflect on non-public methods. </exception>
        public MethodInfo GetAddMethod(bool nonPublic)
        {
            return addMethod.IsPublic || nonPublic ? addMethod : null;
        }

        /// <summary>
        /// When overridden in a derived class, retrieves the MethodInfo object for removing a method of the event, specifying whether to return non-public methods.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MethodInfo"/> object representing the method used to remove an event handler delegate from the event source.
        /// </returns>
        /// <param name="nonPublic">true if non-public methods can be returned; otherwise, false. </param><exception cref="T:System.MethodAccessException"><paramref name="nonPublic"/> is true, the method used to add an event handler delegate is non-public, and the caller does not have permission to reflect on non-public methods. </exception>
        public MethodInfo GetRemoveMethod(bool nonPublic)
        {
            return removeMethod.IsPublic || nonPublic ? removeMethod : null; 
        }

        /// <summary>
        /// Returns the method used to add an event handler delegate to the event source.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MethodInfo"/> object representing the method used to add an event handler delegate to the event source.
        /// </returns>
        public MethodInfo GetAddMethod()
        {
            return GetAddMethod(false);
        }

        /// <summary>
        /// Returns the method used to remove an event handler delegate from the event source.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Reflection.MethodInfo"/> object representing the method used to remove an event handler delegate from the event source.
        /// </returns>
        public MethodInfo GetRemoveMethod()
        {
            return GetRemoveMethod(false);
        }

        /// <summary>
        /// Adds an event handler to an event source.
        /// </summary>
        /// <param name="target">The event source. </param><param name="handler">Encapsulates a method or methods to be invoked when the event is raised by the target. </param><exception cref="T:System.InvalidOperationException">The event does not have a public add accessor.</exception><exception cref="T:System.ArgumentException">The handler that was passed in cannot be used. </exception><exception cref="T:System.MethodAccessException">The caller does not have access permission to the member. </exception><exception cref="T:System.Reflection.TargetException">The <paramref name="target"/> parameter is null and the event is not static.-or- The <see cref="T:System.Reflection.EventInfo"/> is not declared on the target. </exception>
        public virtual void AddEventHandler(object target, Delegate handler)
        {
            MethodInfo addMethod = GetAddMethod();
            if (addMethod == null)
                throw new InvalidOperationException("InvalidOperation_NoPublicAddMethod");
            addMethod.Invoke(target, new[] { handler });
        }

        /// <summary>
        /// Removes an event handler from an event source.
        /// </summary>
        /// <param name="target">The event source. </param><param name="handler">The delegate to be disassociated from the events raised by target. </param><exception cref="T:System.InvalidOperationException">The event does not have a public remove accessor. </exception><exception cref="T:System.ArgumentException">The handler that was passed in cannot be used. </exception><exception cref="T:System.Reflection.TargetException">The <paramref name="target"/> parameter is null and the event is not static.-or- The <see cref="T:System.Reflection.EventInfo"/> is not declared on the target. </exception><exception cref="T:System.MethodAccessException">The caller does not have access permission to the member. </exception>
        public virtual void RemoveEventHandler(object target, Delegate handler)
        {
            MethodInfo removeMethod = this.GetRemoveMethod();
            if (removeMethod == (MethodInfo)null)
                throw new InvalidOperationException("InvalidOperation_NoPublicRemoveMethod");
            removeMethod.Invoke(target, new[] { handler });
        }
    }
}