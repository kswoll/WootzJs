namespace System.Reflection
{
    public struct ParameterModifier
    {
        private bool[] _byRef;

        internal bool[] IsByRefArray
        {
            get { return this._byRef; }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the parameter at the specified index position is to be modified by the current <see cref="T:System.Reflection.ParameterModifier"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the parameter at this index position is to be modified by this <see cref="T:System.Reflection.ParameterModifier"/>; otherwise, false.
        /// </returns>
        /// <param name="index">The index position of the parameter whose modification status is being examined or set. </param>
        public bool this[int index]
        {
            get { return this._byRef[index]; }
            set { this._byRef[index] = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.ParameterModifier"/> structure representing the specified number of parameters.
        /// </summary>
        /// <param name="parameterCount">The number of parameters. </param><exception cref="T:System.ArgumentException"><paramref name="parameterCount"/> is negative. </exception>
        public ParameterModifier(int parameterCount)
        {
            if (parameterCount <= 0)
                throw new ArgumentException("Arg_ParmArraySize");
            this._byRef = new bool[parameterCount];
        }
    }
}